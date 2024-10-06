using LinkDev.Talabat.Core.Domain;
using LinkDev.Talabat.Core.Domain.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.APIs
{
    public class Program
    {
        //[FromServices]
        //public static StoreContext StoreContext { get; set; } = null!;
        
        //[FromServices]
        //public static Logger<Program> _Logger { get; set; } = null!;

        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services
            
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDomainServices(builder.Configuration);

			#endregion

			var app = builder.Build();

            #region Update DataBase [Bug]

            //         try
            //         {
            //             var Migrations = await StoreContext.Database.GetAppliedMigrationsAsync();

            //             if(Migrations.Any())
            //                 await StoreContext.Database.MigrateAsync();
            //         }
            //         catch(Exception ex)
            //         {
            //             _Logger.LogError(ex, "Sorry, An Error Occured :(");
            //}
            //         finally
            //         {
            //             StoreContext.Dispose();
            //         }
            #endregion

            #region Update DataBase

            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

			using var context = services.GetRequiredService<StoreContext>();
            var Logger = services.GetRequiredService<ILogger<Program>>();

            try
            {
				var Migrations = await context.Database.GetPendingMigrationsAsync();

				if(Migrations.Any())
				    await context.Database.MigrateAsync();
			}
			catch (Exception ex)
            {
                Logger.LogError(ex, "Sorry, An Error Occured");
            }

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


            app.MapControllers(); 
            
            #endregion

            app.Run();
        }
    }
}