using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;
using RestaurantManagement.DataService.Interface;
using RestaurantManagement.Common.Constants;
using RestaurantManagement.Common.Enums;

namespace RestaurantManagement.BusinessService.Implementation;

public class InventoryManagementService : IInventoryManagementService
{
    private readonly IInventoryManagementDataService _inventoryManagementDataService;

    public InventoryManagementService(IInventoryManagementDataService inventoryManagementDataService)
    {
        _inventoryManagementDataService = inventoryManagementDataService;
    }

    /// <summary>
    /// Retrieves a list of all inventory items.
    /// </summary>
    public ApiResponse<List<InventoryResponse>> DisplayInventory()
    {
        try
        {
            var inventory = _inventoryManagementDataService.DisplayInventory();
            if (inventory == null)
            {
                return ApiResponse<List<InventoryResponse>>.CreateResponse(ResponseCode.Ok, InventoryConstants.NO_INVENTORY_FOUND_MESSAGE);
            }
            return new ApiResponse<List<InventoryResponse>>(ResponseCode.Ok, ReturnMessage.SUCCESSFUL, inventory);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in DisplayInventory: {ex.Message}");
            return ApiResponse<List<InventoryResponse>>.CreateResponse(ResponseCode.InternalServerError, InventoryConstants.DISPLAY_INVENTORY_ERROR);
        }
    }

    /// <summary>
    /// Updates the quantity of a specific inventory item.
    /// </summary>
    public ApiResponse<InventoryUpdateResponse> UpdateInventory(int id, int quantity)
    {
        try
        {
            if (quantity < 0)
            {
                return ApiResponse<InventoryUpdateResponse>.CreateResponse(ResponseCode.BadRequest, InventoryConstants.NEGATIVE_QUANTITY);
            }

            var result = _inventoryManagementDataService.UpdateInventory(id, quantity);
            if (result == null)
            {
                return ApiResponse<InventoryUpdateResponse>.CreateResponse(ResponseCode.NotFound, InventoryConstants.MENU_ITEM_NOT_FOUND);
            }

            return new ApiResponse<InventoryUpdateResponse>(ResponseCode.Ok, ReturnMessage.SUCCESSFUL, result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in UpdateInventory: {ex.Message}");
            return ApiResponse<InventoryUpdateResponse>.CreateResponse(ResponseCode.InternalServerError, InventoryConstants.INVENTORY_UPDATE_ERROR_MESSAGE);
        }
    }

    /// <summary>
    /// Adds a new menu item to the inventory.
    /// </summary>
    public ApiResponse<Menus> AddNewMenuItem(AddMenuRequest menu)
    {
        try
        {
            if (menu == null)
            {
                return ApiResponse<Menus>.CreateResponse(ResponseCode.BadRequest, InventoryConstants.NULL_VALUE);
            }
            if(menu.Price <= 0)
            {
                return ApiResponse<Menus>.CreateResponse(ResponseCode.BadRequest, InventoryConstants.NEGATIVE_PRICE);
            }
            if(menu.AvailableQuantity <= 0)
            {
                return ApiResponse<Menus>.CreateResponse(ResponseCode.BadRequest, InventoryConstants.NEGATIVE_QUANTITY);
            }

            var newMenu = _inventoryManagementDataService.AddNewMenuItem(menu);
            if (newMenu == null)
            {
                return ApiResponse<Menus>.CreateResponse(ResponseCode.BadRequest, InventoryConstants.ADD_MENU_ITEM_ERROR);
            }
            return new ApiResponse<Menus>(ResponseCode.Created, ReturnMessage.SUCCESSFUL, newMenu);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in AddNewMenuItem: {ex.Message}");
            return ApiResponse<Menus>.CreateResponse(ResponseCode.InternalServerError, InventoryConstants.ADD_MENU_ITEM_ERROR);
        }
    }
}
