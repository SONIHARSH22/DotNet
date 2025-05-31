using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data.Context;

namespace RestaurantManagement.Common.Helper
{
    /// <summary>
    /// use to create database and apply migrations 
    /// </summary>
    public class DatabaseHelper
    {
        public static async Task ApplyMigrationsAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<RestaurentManagementContext>();
            try
            {
                if (!await dbContext.Database.CanConnectAsync())
                {
                    await dbContext.Database.MigrateAsync();
                    Console.WriteLine("MIGRATE");
                }
                else
                {
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
