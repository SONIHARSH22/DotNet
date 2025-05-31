using RestaurantManagement.Models.Entity;
using RestaurantManagement.DataService.Interface;
using RestaurantManagement.Data.Context;

namespace RestaurantManagement.DataService.Implementation
{
    public class OrderFoodDataService : IOrderFoodDataService
    {
        private readonly RestaurentManagementContext _restaurentManagementContext;

        public OrderFoodDataService(RestaurentManagementContext context)
        {
            _restaurentManagementContext = context;
        }

        /// <summary>
        /// Retrieves a menu item by its ID.
        /// </summary>
        /// <param name="menuId">The ID of the menu item.</param>
        /// <returns>The menu item if found; otherwise, null.</returns>
        public Menus? GetMenuById(int menuId)
        {
            return _restaurentManagementContext.Set<Menus>().FirstOrDefault(menu => menu.MenuId == menuId);
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The user if found; otherwise, null.</returns>
        public Users? GetUserById(int userId)
        {
            return _restaurentManagementContext.Set<Users>().FirstOrDefault(user => user.Id == userId);
        }

        /// <summary>
        /// Retrieves a table by its ID.
        /// </summary>
        /// <param name="tableId">The ID of the table.</param>
        /// <returns>The table if found; otherwise, null.</returns>
        public Tables? GetTableById(int tableId)
        {
            return _restaurentManagementContext.Set<Tables>().FirstOrDefault(table => table.TableId == tableId);
        }

        /// <summary>
        /// Retrieves an order by its ID.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <returns>The order if found; otherwise, null.</returns>
        public Orders? GetOrderById(int orderId)
        {
            return _restaurentManagementContext.Set<Orders>().FirstOrDefault(order => order.OrderId == orderId);
        }

        /// <summary>
        /// Saves a new order to the database.
        /// </summary>
        /// <param name="order">The order to be saved.</param>
        public void SaveOrder(Orders order)
        {
            _restaurentManagementContext.Set<Orders>().Add(order);
            _restaurentManagementContext.SaveChanges();
        }

        /// <summary>
        /// Commits pending changes to the database.
        /// </summary>
        public void SaveChanges()
        {
            _restaurentManagementContext.SaveChanges();
        }

        /// <summary>
        /// Updates an existing menu item in the database.
        /// </summary>
        /// <param name="menu">The menu item to be updated.</param>
        public void UpdateMenu(Menus menu)
        {
            _restaurentManagementContext.Set<Menus>().Update(menu);
            _restaurentManagementContext.SaveChanges();
        }

        /// <summary>
        /// Retrieves recent active orders for a given customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>A list of recent active orders.</returns>
        public List<Orders> GetRecentOrdersByCustomerId(int customerId)
        {
            return _restaurentManagementContext.Set<Orders>()
                .Where(order => order.UserId == customerId && order.IsCustomerActive)
                .ToList();
        }

        /// <summary>
        /// Retrieves a list of food items by category.
        /// </summary>
        /// <param name="category">The category of food items.</param>
        /// <returns>A list of food items belonging to the specified category.</returns>
        public List<Menus> GetFoodItemsByCategory(string category)
        {
            return _restaurentManagementContext.Set<Menus>()
                .Where(menu => menu.Category == category)
                .ToList();
        }

        /// <summary>
        /// Retrieves all food items available in the menu.
        /// </summary>
        /// <returns>A list of all food items. Returns an empty list if an error occurs.</returns>
        public List<Menus> GetAllFoodItems()
        {
            try
            {
                return _restaurentManagementContext.Set<Menus>().ToList();
            }
            catch (Exception)
            {
                return new List<Menus>();
            }
        }
    }
}