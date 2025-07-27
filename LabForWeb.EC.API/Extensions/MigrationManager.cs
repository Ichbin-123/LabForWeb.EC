using LabForWeb.EC.DAL;
using Microsoft.EntityFrameworkCore;
namespace LabForWeb.EC.API.Extensions;

public static class MigrationManager
{
    public static WebApplication MigrateDataBase(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();        
        using var dc = scope.ServiceProvider.GetRequiredService<ECContext>();

        try
        {
            dc.Database.Migrate();
            Console.WriteLine("MIGRAZIONI APPLICATE CON SUCCESSO");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERRORE MIGRAZIONE: " + ex.Message);
        }

        return webApp;
        
    }
}
