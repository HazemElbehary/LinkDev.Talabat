using LinkDev.Talabat.APIs.Extensions;
using LinkDev.Talabat.APIs.LoggedInUserServices;
using LinkDev.Talabat.Core.Application.Abstraction.LoggedInUserServices;
using LinkDev.Talabat.Core.Application.DepaendancyInjection;
using LinkDev.Talabat.Core.Domain;
using LinkDev.Talabat.APIs.Controllers;

namespace LinkDev.Talabat.APIs
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services
            
            // Add services to the container.

            builder.Services.AddControllers().AddApplicationPart(typeof(Controllers.AssemblyInformation).Assembly);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpContextAccessor();
			builder.Services.AddScoped(typeof(ILoggedInUserService), typeof(LoggedInUserService));
			builder.Services.AddPresistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();
			#endregion

			var app = builder.Build();

            #region DataBase Initialization

            await app.InitializeStoreContext();
			
            #endregion

            #region Configure MiddleWares

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