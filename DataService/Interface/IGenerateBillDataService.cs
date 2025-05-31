using RestaurantManagement.Models.Entity;

namespace RestaurantManagement.DataService.Interface
{
    /// <summary>
    /// Provides data access operations for generating bills, retrieving customer orders, and managing tables.
    /// </summary>
    public interface IGenerateBillDataService
    {
        /// <summary>
        /// Retrieves all orders placed by a specific customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>List of orders placed by the customer.</returns>
        List<Orders> GetCustomerOrders(int customerId);

        /// <summary>
        /// Retrieves user details based on the customer ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>The user details if found, otherwise null.</returns>
        Users? GetUserById(int customerId);

        /// <summary>
        /// Retrieves the name of a menu item based on its ID.
        /// </summary>
        /// <param name="menuId">The ID of the menu item.</param>
        /// <returns>The name of the menu item if found, otherwise null.</returns>
        string? GetMenuItemName(int menuId);

        /// <summary>
        /// Updates the status of multiple orders in the database.
        /// </summary>
        /// <param name="orders">The list of orders to be updated.</param>
        void UpdateOrders(List<Orders> orders);

        /// <summary>
        /// Frees a table by updating its availability status.
        /// </summary>
        /// <param name="tableId">The ID of the table to be freed.</param>
        void FreeTable(int tableId);

        /// <summary>
        /// Saves changes made to the database.
        /// </summary>
        void SaveChanges();
    }
}