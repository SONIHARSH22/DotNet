using RestaurantManagement.Models.Entity;
using RestaurantManagement.DataService.Interface;
using RestaurantManagement.Data.Context;

namespace RestaurantManagement.DataService.Implementation
{
    public class BookTableDataService : IBookTableDataService
    {
        private readonly RestaurentManagementContext restaurentmanagementcontext;

        public BookTableDataService(RestaurentManagementContext context)
        {
            restaurentmanagementcontext = context;
        }

        /// <summary>
        /// Retrieves all tables in the restaurant.
        /// </summary>
        /// <returns>A list of all tables, or an empty list in case of an error.</returns>
        public List<Tables> GetAllTables()
        {
            try
            {
                return restaurentmanagementcontext.Set<Tables>().ToList();
            }
            catch (Exception)
            {
                return new List<Tables>();
            }
        }

        /// <summary>
        /// Retrieves all available (unoccupied) tables in the restaurant.
        /// </summary>
        /// <returns>A list of available tables, or an empty list in case of an error.</returns>
        public List<Tables> GetAvailableTables()
        {
            try
            {
                return restaurentmanagementcontext.Set<Tables>().Where(table => !table.IsOccupied).ToList();
            }
            catch (Exception)
            {
                return new List<Tables>();
            }
        }

        /// <summary>
        /// Retrieves a specific table by its ID.
        /// </summary>
        /// <param name="tableId">The ID of the table.</param>
        /// <returns>The table details if found, otherwise null.</returns>
        public Tables? GetTableById(int tableId)
        {
            return restaurentmanagementcontext.Set<Tables>().FirstOrDefault(existing => existing.TableId == tableId);
        }

        /// <summary>
        /// Updates table details in the database.
        /// </summary>
        /// <param name="table">The table entity with updated information.</param>
        public void UpdateTable(Tables table)
        {
            restaurentmanagementcontext.SaveChanges();
        }
    }
}