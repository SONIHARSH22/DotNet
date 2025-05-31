using RestaurantManagement.Models.Entity;
using RestaurantManagement.DataService.Interface;
using RestaurantManagement.Data.Context;

namespace RestaurantManagement.DataService.Implementation
{
    public class GenerateBillDataService : IGenerateBillDataService
    {
        private readonly RestaurentManagementContext _restaurentManagementContext;

        public GenerateBillDataService(RestaurentManagementContext context)
        {
            _restaurentManagementContext = context;
        }

        /// <summary>
        /// Retrieves all active orders for a specific customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>A list of active orders placed by the customer.</returns>
        public List<Orders> GetCustomerOrders(int customerId)
        {
            return _restaurentManagementContext.Set<Orders>()
                .Where(order => order.UserId == customerId && order.IsCustomerActive)
                .ToList();
        }

        /// <summary>
        /// Retrieves user details by their ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>The user entity if found, otherwise null.</returns>
        public Users? GetUserById(int customerId)
        {
            return _restaurentManagementContext.Set<Users>().FirstOrDefault(user => user.Id == customerId);
        }

        /// <summary>
        /// Retrieves the name of a menu item based on its ID.
        /// </summary>
        /// <param name="menuId">The ID of the menu item.</param>
        /// <returns>The name of the menu item if found, otherwise null.</returns>
        public string? GetMenuItemName(int menuId)
        {
            return _restaurentManagementContext.Set<Menus>().FirstOrDefault(menu => menu.MenuId == menuId)?.Name;
        }

        /// <summary>
        /// Marks a list of orders as inactive for the customer.
        /// </summary>
        /// <param name="orders">The list of orders to be updated.</param>
        public void UpdateOrders(List<Orders> orders)
        {
            foreach (var order in orders)
            {
                order.IsCustomerActive = false;
            }
        }

        /// <summary>
        /// Frees an occupied table by updating its status.
        /// </summary>
        /// <param name="tableId">The ID of the table to be freed.</param>
        public void FreeTable(int tableId)
        {
            var table = _restaurentManagementContext.Set<Tables>().FirstOrDefault(t => t.TableId == tableId);
            if (table != null)
            {
                table.IsOccupied = false;
            }
        }

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        public void SaveChanges()
        {
            _restaurentManagementContext.SaveChanges();
        }
    }
}