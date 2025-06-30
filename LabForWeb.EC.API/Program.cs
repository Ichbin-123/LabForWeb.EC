
using LabForWeb.EC.DAL;
using Microsoft.EntityFrameworkCore;

namespace LabForWeb.EC.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region
            builder.Services.AddDbContext<ECContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("default"))
            );
            #endregion


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //************** Aggiungiamo documentazione SWAGGER ********************//

            builder.Services.AddEndpointsApiExplorer(); // Espone all'esterno verso un endpoint
            builder.Services.AddSwaggerGen(); // Genera l'interfaccia grafica


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            #region Applicazione Migrazioni
            
            #endregion

            app.Run();
        }
    }
}
