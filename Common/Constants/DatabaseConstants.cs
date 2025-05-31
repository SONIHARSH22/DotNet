namespace RestaurantManagement.Common.Constants
{
    /// <summary>
    /// datsbase constants has parameters, stored procedures and columns names
    /// </summary>
    public static class DatabaseConstants
    {
        public const string CONNECTION_STRING_NAME = "defaultConnection";
        public const string STORED_PROCEDURE_GENERATE_BILL = "GenerateBill";

        public static class StoredProcedures
        {
            public const string GET_ALL_MENU_ITEMS = "GetAllMenuItems";
            public const string PLACE_ORDER = "PlaceOrder";
            public const string SEE_RECENT_ORDERS = "SeeYourRecentOrders";
            public const string UPDATE_ORDER = "UpdateOrder";
            public const string CANCEL_ORDER = "CancelOrder";
            public const string REGISTER_USER = "usp_RegisterUser";
            public const string USER_LOGIN = "UserLogin";
        }

        public static class Parameters
        {
            public const string GRAND_TOTAL = "@GrandTotal";
            public const string CUSTOMER_ID = "@CustomerId";
            public const string TABLE_ID = "@TableId";
            public const string MENU_ID = "@MenuId";
            public const string QUANTITY = "@Quantity";
            public const string PRICE = "@Price";
            public const string ORDER_ID = "@OrderId";
            public const string OUT_ORDER_ID = "@OutOrderId";
            public const string OUT_TABLE_ID = "@OutTableId";
            public const string NAME = "@Name";
            public const string OUT_QUANTITY = "@OutQuantity";
            public const string OUT_PRICE = "@OutPrice";
            public const string MESSAGE = "@Message";
            public const string MENU_NAME = "@MenuName";
            public const string UPDATED_QUANTITY = "@UpdatedQuantity";
            public const string USER_ID = "@UserId";
            public const string EMAIL = "@Email";
            public const string PHONE = "@Phone";
            public const string HASHED_PASSWORD = "@HashedPassword";
            public const string ROLE = "@Role";
            public const string ID = "@Id";
            public const string STORED_PASSWORD = "@StoredPassword";
            public const int MENU_NAME_MAX_LENGTH = 255;
            public const int MESSAGE_MAX_LENGTH = 255;
            public const int DECIMAL_PRECISION = 10;
            public const int DECIMAL_SCALE = 2;

            public const string PASSWORD_NULL_MESSAGE = "Password cannot be null";
            public const string USER_ALREADY_EXISTS_MESSAGE = "User already registered with this email SP.";
            public const string USER_REGISTERED_SUCCESS_MESSAGE = "User registered successfully SP.";
            public const string INVALID_CREDENTIALS_MESSAGE = "Invalid username or password.";
            public const string LOGIN_SUCCESS_MESSAGE = "Login successful.";
            public const string ERROR_MESSAGE = "Error: ";
        }

        public static class Columns
        {
            public const string ORDER_ID = "OrderId";
            public const string USER_ID = "UserId";
            public const string MENU_NAME = "MenuName";
            public const string QUANTITY = "Quantity";
            public const string PRICE = "Price";
        }
    }
}

