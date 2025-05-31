namespace RestaurantManagement.Common.Constants
{
    /// <summary>
    /// API Endpoints Constants
    /// </summary>
    public static class ApisEndpoints
    {
        public const string API_CONTROLLER = "api/[controller]";
        public const string GET_ALL_MENU = "GetAllMenu";
        public const string ORDER_FOOD = "OrderFood";
        public const string SEE_YOUR_RECENT_ORDER = "recent/{customerId}";
        public const string UPDATE_ORDER = "UpdateOrder";
        public const string CANCEL_ORDER = "CancelOrder/order_id/{orderId}/customer_id/{customerId}";
        public const string GENERATE_BILL = "GenerateBill/{customerId}";
        public const string REGISTER = "register";
        public const string LOGIN = "login";
        public const string GET_ALL_TABLES = "GetAllTables";
        public const string SELECT_AVAILABLE_TABLE = "SelectAvailableTable";
        public const string BOOK_TABLE = "BookTable";
        public const string CANCEL_TABLE = "CancelTable";
        public const string INVENTORY_CONTROLLER_ROUTE = "api/InventoryManagement";
        public const string SHOW_INVENTORY_END_POINT = "ShowInventory";
        public const string UPDATE_INVENTORY_END_POINT = "UpdateInventory/inventory_id/{id}/quantity/{quantity}";
        public const string ADD_MENU_ITEM_ENDPOINT = "AddMenuItem";
        public const string ADMIN_CONTROLLER_ROUTE = "api/AdminManagement";
        public const string PENDING_ORDERS_ENDPOINT = "PendingOrders";
        public const string MARK_ATTENDANCE_ENDPOINT = "MarkAttendance";
        public const string FOOD_ORDER_ANALYSIS_ENDPOINT = "food_order_analysis/year/{year}/month/{month}";
        public const string SEARCH_BY_CATEGORY = "GetFoodItemsByCategory/{category}";

    }
}