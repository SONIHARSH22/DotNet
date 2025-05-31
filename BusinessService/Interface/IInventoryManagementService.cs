using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;

namespace RestaurantManagement.BusinessService.Interface;

public interface IInventoryManagementService
{
    /// <summary>
    /// Retrieves a list of all inventory items and their details.
    /// </summary>
    /// <returns>A list of InventoryResponse objects representing the inventory.</returns>
    ApiResponse<List<InventoryResponse>> DisplayInventory();

    /// <summary>
    /// Updates the quantity of a specific inventory item.
    /// </summary>
    /// <param name="id">The ID of the inventory item to update.</param>
    /// <param name="quantity">The new quantity for the inventory item.</param>
    /// <returns>An InventoryUpdateResponse object indicating the result of the update.</returns>
    ApiResponse<InventoryUpdateResponse> UpdateInventory(int id, int quantity);

    /// <summary>
    /// Adds a new menu item to the inventory.
    /// </summary>
    /// <param name="menu">The AddMenu object containing the details of the new menu item.</param>
    /// <returns>A Menus object representing the newly added menu item.</returns>
    ApiResponse<Menus> AddNewMenuItem(AddMenuRequest menu);
}