using RestaurantManagement.Models.Entity;

namespace RestaurantManagement.DataService.Interface
{
    public interface IBookTableDataService
    {
        /// <summary>
        /// Retrieves a list of all tables present in the restaurant.
        /// </summary>
        /// <returns>A list of all tables.</returns>
        List<Tables> GetAllTables();

        /// <summary>
        /// Retrieves a list of all available (unoccupied) tables in the restaurant.
        /// </summary>
        /// <returns>A list of available tables.</returns>
        List<Tables> GetAvailableTables();

        /// <summary>
        /// Retrieves details of a specific table by its ID.
        /// </summary>
        /// <param name="tableId">The ID of the table.</param>
        /// <returns>The table details, including ID, seating capacity, and occupancy status.</returns>
        Tables? GetTableById(int tableId);

        /// <summary>
        /// Updates the table information in the database.
        /// </summary>
        /// <param name="table">The table entity containing updated information.</param>
        void UpdateTable(Tables table);
    }
}