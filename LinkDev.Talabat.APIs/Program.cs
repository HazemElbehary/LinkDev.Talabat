using LinkDev.Talabat.APIs.Controllers.Errors;
using LinkDev.Talabat.APIs.Controllers.Middlewares;
using LinkDev.Talabat.APIs.Extensions;
using LinkDev.Talabat.APIs.LoggedInUserServices;
using LinkDev.Talabat.Core.Application.Abstraction.LoggedInUserServices;
using LinkDev.Talabat.Core.Application.DepaendancyInjection;
using LinkDev.Talabat.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using LinkDev.Talabat.Infrastructure;
using LinkDev.Talabat.Core.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace LinkDev.Talabat.APIs
{
	public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services
            
            // Add services to the container.

            builder.Services
                .AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = false;
                    options.InvalidModelStateResponseFactory = actionContext =>
                    {

                        var Errors = actionContext.ModelState
                        .Where(P => P.Value!.Errors.Count > 0)
                        .ToDictionary(
                            p => p.Key,
                            p => p.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                        );
						return new BadRequestObjectResult(new ApiValidationErrorResponse() { Errors = Errors });
					};
                })
                .AddApplicationPart(typeof(Controllers.AssemblyInformation).Assembly);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpContextAccessor();
			builder.Services.AddScoped(typeof(ILoggedInUserService), typeof(LoggedInUserService));
			builder.Services.AddPresistenceServices(builder.Configuration);
            builder.Services.AddInfrastructure(builder.Configuration);
			builder.Services.AddApplicationServices();

            builder.Services.AddIdentityService();

			#endregion

			var app = builder.Build();

            #region DataBase Initialization

            await app.InitializeStoreContext();

            #endregion

            #region Configure MiddleWares

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseStatusCodePagesWithReExecute("/Error/{0}");


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers(); 
            
            #endregion

            app.Run();
        }
    }
}