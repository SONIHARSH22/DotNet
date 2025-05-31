using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.Common.Constants;
using RestaurantManagement.Common.Enums;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;
using RestaurantManagement.DataService.Interface;

namespace RestaurantManagement.BusinessService.Implementation;

public class OrderFoodService : IOrderFoodService
{
    private readonly IOrderFoodDataService _foodOrderingDataService;

    public OrderFoodService(IOrderFoodDataService foodOrderingDataService)
    {
        _foodOrderingDataService = foodOrderingDataService;
    }

    /// <summary>
    /// Get all food items present in the restaurant menu
    /// </summary>
    /// <returns> Return list of all Menus</returns>
    public ApiResponse<List<Menus>> GetAllFoodItems()
    {
        try
        {
            List<Menus> menus = _foodOrderingDataService.GetAllFoodItems();
            if(menus == null) {
                return ApiResponse<List<Menus>>.CreateResponse(ResponseCode.Ok, ReturnMessage.MENU_ITEM_NOT_FOUND);
            }
            return new ApiResponse<List<Menus>>(ResponseCode.Ok, ReturnMessage.SUCCESSFUL, menus);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return ApiResponse<List<Menus>>.CreateResponse(ResponseCode.InternalServerError, ReturnMessage.ERROR_OCCURRED);
        }
    }

    /// <summary>
    /// Order food which you want by give menuid, quantity, tableId and userId
    /// </summary>
    /// <param name="orderRequest"></param>
    /// <returns> retur order what you palces </returns>
    public ApiResponse<OrderResponse> OrderFood(OrderRequest orderRequest)
    {
        try
        {
            if (orderRequest.Quantity <= 0)
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.NEGATIVE_QUANTITY_NOT_ALLOWED);

            Menus? existingMenu = _foodOrderingDataService.GetMenuById(orderRequest.MenuId);
            if (existingMenu == null)
                return  ApiResponse<OrderResponse>.CreateResponse(ResponseCode.NotFound, ReturnMessage.MENU_ITEM_NOT_FOUND);

            if (existingMenu.AvailableQuantity < orderRequest.Quantity)
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.INSUFFICIENT_QUANTITY_AVAILABLE);

            Users? existingUser = _foodOrderingDataService.GetUserById(orderRequest.CustomerId);
            if (existingUser == null)
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.NotFound, ReturnMessage.USER_NOT_FOUND);

            Tables? existingTable = _foodOrderingDataService.GetTableById(orderRequest.TableId);
            if (existingTable == null)
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.NotFound, ReturnMessage.TABLE_NOT_FOUND);

            Orders order = new Orders
            {
                UserId = orderRequest.CustomerId,
                TableId = orderRequest.TableId,
                MenuId = orderRequest.MenuId,
                Quantity = orderRequest.Quantity,
                Price = (decimal)existingMenu.Price!,
                IsCustomerActive = true,
                OrderStatus = (int)OrderStatus.Pending
            };

            existingMenu.AvailableQuantity -= orderRequest.Quantity;
            _foodOrderingDataService.UpdateMenu(existingMenu);
            _foodOrderingDataService.SaveOrder(order);

            return new ApiResponse<OrderResponse>(ResponseCode.Ok, ReturnMessage.ORDER_SUCCESSFUL, new OrderResponse
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                TableId = order.TableId,
                Name = existingMenu.Name!,
                Quantity = order.Quantity,
                Price = order.Price
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.InternalServerError, ReturnMessage.ERROR_OCCURRED);

        }
    }

    /// <summary>
    /// See your all recent orders you placed
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    public ApiResponse<List<OrderResponse>> SeeYourRecentOrders(int customerId)
    {
        try
        {
            List<Orders> existingOrders = _foodOrderingDataService.GetRecentOrdersByCustomerId(customerId);

            if (existingOrders.Count == 0)
            {
              return ApiResponse<List<OrderResponse>>.CreateResponse(ResponseCode.NotFound, ReturnMessage.NO_ORDER_FOUND);

            }

            List<OrderResponse> orderResponses = new List<OrderResponse>();

            foreach (Orders order in existingOrders)
            {
                Menus? existingMenu = _foodOrderingDataService.GetMenuById(order.MenuId);
                if (existingMenu == null)
                {
                    return ApiResponse<List<OrderResponse>>.CreateResponse(ResponseCode.NotFound, ReturnMessage.MENU_ITEM_NOT_FOUND);

                }

                orderResponses.Add(new OrderResponse
                {
                    OrderId = order.OrderId,
                    UserId = order.UserId,
                    TableId = order.TableId,
                    Name = existingMenu.Name!,
                    Quantity = order.Quantity,
                    Price = order.Price,
                    message = $"Order Status: {GetOrderStatusString(order.OrderStatus)}"
                });
            }

            return new ApiResponse<List<OrderResponse>>(ResponseCode.Ok,ReturnMessage.SUCCESSFUL, orderResponses);
        }
        catch (Exception ex)
        {
            return ApiResponse<List<OrderResponse>>.CreateResponse(ResponseCode.InternalServerError, ReturnMessage.ERROR_OCCURRED);

        }
    }
    private string GetOrderStatusString(int status)
    {
        return Enum.GetName(typeof(OrderStatus), status) ?? "Unknown";
    }
    
    public ApiResponse<OrderResponse> UpdateOrder(UpdateOrderRequest updateOrder)
    {
        try
        {
            Orders? existingOrder = _foodOrderingDataService.GetOrderById(updateOrder.OrderId);
            if (existingOrder == null)
            {
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.NotFound, ReturnMessage.NO_ORDER_FOUND);
            }

            if (!existingOrder.IsCustomerActive)
            {
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.USER_NOT_ACTIVE);
            }

            if (existingOrder.OrderStatus == (int)OrderStatus.Cancelled || existingOrder.OrderStatus == (int)OrderStatus.Served)
            {
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.CANNOT_UPDATE_ORDER);
            }

            if (existingOrder.UserId != updateOrder.UserId)
            {
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.Unauthorized, ReturnMessage.UNAUTHORIZED_ACCESS);
            }

            if (existingOrder.Quantity <= 0)
            {
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.NEGATIVE_QUANTITY_NOT_ALLOWED);
            }

            Menus? existingMenu = _foodOrderingDataService.GetMenuById(existingOrder.MenuId);
            if (existingMenu == null)
            {
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.NotFound, ReturnMessage.MENU_ITEM_NOT_FOUND);
            }

            existingMenu.AvailableQuantity += existingOrder.Quantity;

            if (existingMenu.AvailableQuantity < updateOrder.Quantity)
            {
                existingMenu.AvailableQuantity -= existingOrder.Quantity;
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.INSUFFICIENT_QUANTITY_AVAILABLE);
            }

            existingMenu.AvailableQuantity -= updateOrder.Quantity;
            existingOrder.Quantity = updateOrder.Quantity;

            _foodOrderingDataService.SaveChanges();

            return new ApiResponse<OrderResponse>(ResponseCode.Ok, ReturnMessage.SUCCESSFUL, new OrderResponse
            {
                OrderId = existingOrder.OrderId,
                UserId = existingOrder.UserId,
                TableId = existingOrder.TableId,
                Name = existingMenu.Name!,
                Quantity = existingOrder.Quantity,
                Price = existingOrder.Price
            });
        }
        catch (Exception)
        {
            return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.InternalServerError, ReturnMessage.ERROR_OCCURRED);
        }
    }

    public ApiResponse<OrderResponse> CancelOrder(int orderId, int customerId)
    {
        try
        {
            Orders? existingOrder = _foodOrderingDataService.GetOrderById(orderId);
            if (existingOrder == null)
            {
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.NotFound, ReturnMessage.NO_ORDER_FOUND);
            }

            if (!existingOrder.IsCustomerActive)
            {
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.USER_NOT_ACTIVE);
            }

            if (existingOrder.OrderStatus == (int)OrderStatus.Cancelled || existingOrder.OrderStatus == (int)OrderStatus.Served)
            {
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.CANNOT_CANCLE_ORDER);
            }

            if (existingOrder.UserId != customerId)
            {
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.Unauthorized, ReturnMessage.UNAUTHORIZED_ACCESS);
            }

            Menus? existingMenu = _foodOrderingDataService.GetMenuById(existingOrder.MenuId);
            if (existingMenu == null)
            {
                return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.NotFound, ReturnMessage.MENU_ITEM_NOT_FOUND);
            }

            existingMenu.AvailableQuantity += existingOrder.Quantity;
            existingOrder.OrderStatus = (int)OrderStatus.Pending;

            _foodOrderingDataService.SaveChanges();

            return new ApiResponse<OrderResponse>(ResponseCode.Ok, ReturnMessage.ORDER_CANCELLED_SUCCESSFULLY, new OrderResponse
            {
                OrderId = existingOrder.OrderId,
                UserId = existingOrder.UserId,
                TableId = existingOrder.TableId,
                Name = existingMenu.Name!,
                Quantity = existingOrder.Quantity,
                Price = existingOrder.Price,
            });
        }
        catch (Exception ex)
        {
            return ApiResponse<OrderResponse>.CreateResponse(ResponseCode.InternalServerError, ex.Message);
        }
    }

    public ApiResponse<List<Menus>> GetFoodItemsByCategory(string category)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return ApiResponse<List<Menus>>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.EMPTY_CATEGORY);
            }

            category = char.ToUpper(category[0]) + category.Substring(1).ToLower();
            List<Menus> menus = _foodOrderingDataService.GetFoodItemsByCategory(category);

            return new  ApiResponse<List<Menus>>(ResponseCode.Ok, ReturnMessage.SUCCESSFUL, menus);
        }
        catch (Exception ex)
        {
            return ApiResponse<List<Menus>>.CreateResponse(ResponseCode.InternalServerError, ex.Message, new List<Menus>());
        }
    }
}