using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;

namespace RestaurantManagement.DataService.Interface
{
    public interface IInventoryManagementDataService
    {
        /// <summary>
        /// Retrieves the current inventory of menu items.
        /// </summary>
        /// <returns>A list of InventoryResponse objects.</returns>
        List<InventoryResponse> DisplayInventory();

        /// <summary>
        /// Updates the quantity of a specific inventory item.
        /// </summary>
        /// <param name="id">The ID of the inventory item.</param>
        /// <param name="quantity">The new quantity.</param>
        /// <returns>An InventoryUpdateResponse object, or null if the item is not found.</returns>
        InventoryUpdateResponse? UpdateInventory(int id, int quantity);

        /// <summary>
        /// Adds a new menu item to the inventory.
        /// </summary>
        /// <param name="menu">The AddMenu object containing the menu details.</param>
        /// <returns>The newly created Menus object.</returns>
        Menus AddNewMenuItem(AddMenuRequest menu);
    }
}
