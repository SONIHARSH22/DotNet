﻿namespace RestaurantManagement.Common.Enums
{
    public enum ResponseCode
    {
        Ok = 200,
        Created = 201,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        Conflict = 409,
        InternalServerError = 500
    }
}
