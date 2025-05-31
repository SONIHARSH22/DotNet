using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.Common.Constants;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;

namespace RestaurantManagement.Controllers
{
    [Authorize(Roles = UserRoles.ADMIN)]
    [Route(ApisEndpoints.API_CONTROLLER)]
    [ApiController]
    public class InventoryManagementByAdminController : BaseController
    {
        private readonly IInventoryManagementService _inventoryManagement;

        public InventoryManagementByAdminController(IInventoryManagementService inventoryBusinessService)
        {
            _inventoryManagement = inventoryBusinessService;
        }

        [HttpGet(ApisEndpoints.SHOW_INVENTORY_END_POINT)]
        public IActionResult GetInventory()
        {
            ApiResponse<List<InventoryResponse>> inventoryList = _inventoryManagement.DisplayInventory();
            return GenerateResponse(inventoryList);
        }

        [HttpPut(ApisEndpoints.UPDATE_INVENTORY_END_POINT)]
        public IActionResult UpdateInventory(int id, int quantity)
        {
            ApiResponse<InventoryUpdateResponse> response = _inventoryManagement.UpdateInventory(id, quantity);
            return GenerateResponse(response);
        }

        [HttpPost(ApisEndpoints.ADD_MENU_ITEM_ENDPOINT)]
        public IActionResult AddNewMenuItem(AddMenuRequest menu)
        {
            ApiResponse<Menus> addedMenu = _inventoryManagement.AddNewMenuItem(menu);
            return GenerateResponse(addedMenu);
        }
    }
}