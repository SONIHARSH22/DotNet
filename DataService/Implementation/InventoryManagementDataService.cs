using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;
using RestaurantManagement.DataService.Interface;
using RestaurantManagement.Data.Context;

namespace RestaurantManagement.DataService.Implementation
{
    public class InventoryManagementDataService : IInventoryManagementDataService
    {
        private readonly RestaurentManagementContext _context;

        public InventoryManagementDataService(RestaurentManagementContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves the current inventory of all menu items, including their quantity and category.
        /// </summary>
        /// <returns>A list of inventory items with details.</returns>
        public List<InventoryResponse> DisplayInventory()
        {
            return _context.Set<Menus>()
                .Select(menu => new InventoryResponse
                {
                    InventoryId = menu.MenuId,
                    Name = menu.Name,
                    AvailableQuantity = menu.AvailableQuantity,
                    Category = menu.Category
                }).ToList();
        }

        /// <summary>
        /// Updates the quantity of a specific inventory item.
        /// </summary>
        /// <param name="id">The ID of the inventory item.</param>
        /// <param name="quantity">The new quantity to update.</param>
        /// <returns>The updated inventory details if successful, otherwise null.</returns>
        public InventoryUpdateResponse? UpdateInventory(int id, int quantity)
        {
            var menu = _context.Set<Menus>().Find(id);

            if (menu == null)
            {
                return null;
            }

            int previousQuantity = menu.AvailableQuantity;
            menu.AvailableQuantity = quantity;
            _context.SaveChanges();

            return new InventoryUpdateResponse
            {
                InventoryId = menu.MenuId,
                Name = menu.Name,
                PreviousQuantity = previousQuantity,
                UpdatedQuantity = menu.AvailableQuantity,
                Category = menu.Category
            };
        }

        /// <summary>
        /// Adds a new menu item to the inventory.
        /// </summary>
        /// <param name="menu">The details of the new menu item to be added.</param>
        /// <returns>The newly added menu item entity.</returns>
        public Menus AddNewMenuItem(AddMenuRequest menu)
        {
            var newMenu = new Menus
            {
                Name = menu.Name,
                Price = menu.Price,
                Description = menu.Description,
                AvailableQuantity = menu.AvailableQuantity,
                Category = menu.Category
            };

            _context.Set<Menus>().Add(newMenu);
            _context.SaveChanges();
            return newMenu;
        }
    }
}