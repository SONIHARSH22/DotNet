namespace RestaurantManagement.Common.Constants
{
    /// <summary>
    /// Constants for all type of return messages
    /// </summary>
    public static class ReturnMessage
    {
        public const string USER_REGISTERED_SUCCESSFULLY = "User registered successfully.";
        public const string LOGIN_SUCCESSFUL = "Login successful.";
        public const string CUSTOMER_REGISTERED_SUCCESSFULL = "Customer registered successfully.";
        public const string ORDER_SUCCESSFUL = "Order successful.";
        public const string BILL_GENERATED_SUCCESSFULLY = "Bill generated successfully.";
        public const string ORDER_CANCELLED_SUCCESSFULLY = "Order cancelled successfully.";
        public const string TABLE_BOOKED_SUCCESSFULLY = "Table booked successfully.";
        public const string TABLE_RESERVED_SUCCESSFULLY = "Table reserved successfully.";
        public const string TABLE_CANCELLED_SUCCESSFULLY = "Table cancelled successfully.";
        public const string ORDER_UPDATED_SUCCESSFULLY = "Order updated successfully.";
        public const string SUCCESSFUL = "Successful";

        public const string CUSTOMER_REGISTER_FAILED = "Customer registration failed.";
        public const string CUSTOMER_LOGIN_FAILED = "Customer login failed.";
        public const string USER_ALREADY_REGISTERED = "User is already registered.";
        public const string USER_NOT_FOUND = "User not found.";
        public const string INVALID_CREDENTIALS = "Invalid credentials.";
        public const string BILL_GENERATION_FAILED = "Bill Generation failed.";
        public const string NO_ORDER_FOUND = "No order found.";
        public const string MENU_ITEM_NOT_FOUND = "Menu item not found.";
        public const string INSUFFICIENT_QUANTITY_AVAILABLE = "Insufficient quantity available.";
        public const string ORDER_FAILED = "Order failed.";
        public const string TABLE_NOT_FOUND = "Table not found.";
        public const string TABLE_ALREADY_OCCUPIED = "Table is already occupied.";
        public const string TABLE_ALREADY_RESERVED = "Table is already reserved.";
        public const string TABLE_BOOKING_FAILED = "Table booking failed.";
        public const string INVALID_ROLEID = "Invalid RoleId provided";
        public const string BILLING_ERROR_MESSAGE = "An error occurred while generating the bill.";
        public const string PASSWORD = "Stored password cannot be null";
        public const string UNAUTHORIZED_ACCESS = "You cannot update others order or OrderId mismatch";
        public const string TABLE_NOT_OCCUPIED = "Table is not occupied by any one cannot cancle.";
        public const string CANNOT_UPDATE_ORDER = "Order is Already Served or Canceled";
        public const string CANNOT_CANCLE_ORDER = "Order is Already Served or Canceled";
        public const string USER_NOT_ACTIVE = "This Customer is not Active Now";
        public const string CUSTOMER_ID_NEEDED = "CustomerId cannot be empty";
        public const string INVALID_CUSTOMER_ID = "Invalid CustomerId";
        public const string NEGATIVE_QUANTITY_NOT_ALLOWED = "Quantity cannot be Negative or Zero";
        public const string ERROR_OCCURRED = "An error occurred while processing the request.";
        public const string EMPTY_CATEGORY = "Category cannot be empty";

    }
}