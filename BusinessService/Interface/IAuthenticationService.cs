using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;

namespace RestaurantManagement.BusinessService.Interface;

public interface IAuthenticationService
{
    /// <summary>
    /// Registers a new user based on the provided registration details.
    /// </summary>
    /// <param name="userRegister">The UserRegister object containing user registration information.</param>
    /// <returns>A string message indicating the result of the registration.</returns>
    ApiResponse<RegisterResponse> UserRegister(RegisterRequest userRegister);

    /// <summary>
    /// Authenticates a user based on the provided login credentials.
    /// </summary>
    /// <param name="userlogin">The UserLogin object containing user login credentials.</param>
    /// <returns>A LoginResponse object containing authentication results and user information.</returns>
    ApiResponse<LoginResponse> UserLogin(LoginRequest userlogin);
}