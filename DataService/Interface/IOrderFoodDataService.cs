using RestaurantManagement.Models.Entity;

namespace RestaurantManagement.DataService.Interface
{
    public interface IOrderFoodDataService
    {
        /// <summary>
        /// Retrieves a list of all available food items.
        /// </summary>
        /// <returns>List of menu items.</returns>
        List<Menus> GetAllFoodItems();

        /// <summary>
        /// Retrieves food items based on the specified category.
        /// </summary>
        /// <param name="category">The category of food items.</param>
        /// <returns>List of menu items in the specified category.</returns>
        List<Menus> GetFoodItemsByCategory(string category);

        /// <summary>
        /// Retrieves a menu item by its unique identifier.
        /// </summary>
        /// <param name="menuId">The ID of the menu item.</param>
        /// <returns>The menu item if found, otherwise null.</returns>
        Menus? GetMenuById(int menuId);

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The user if found, otherwise null.</returns>
        Users? GetUserById(int userId);

        /// <summary>
        /// Retrieves a table by its unique identifier.
        /// </summary>
        /// <param name="tableId">The ID of the table.</param>
        /// <returns>The table if found, otherwise null.</returns>
        Tables? GetTableById(int tableId);

        /// <summary>
        /// Saves a new order to the database.
        /// </summary>
        /// <param name="order">The order details to be saved.</param>
        void SaveOrder(Orders order);

        /// <summary>
        /// Updates an existing menu item in the database.
        /// </summary>
        /// <param name="menu">The menu item to be updated.</param>
        void UpdateMenu(Menus menu);

        /// <summary>
        /// Retrieves a list of recent orders placed by a specific customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>List of recent orders.</returns>
        List<Orders> GetRecentOrdersByCustomerId(int customerId);

        /// <summary>
        /// Retrieves an order by its unique identifier.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <returns>The order if found, otherwise null.</returns>
        Orders? GetOrderById(int orderId);

        /// <summary>
        /// Saves changes made to the database.
        /// </summary>
        void SaveChanges();
    }
}