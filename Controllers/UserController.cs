using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models.Request;
using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.Common.Constants;
using RestaurantManagement.Models.Response;

namespace RestaurantManagement.Controllers
{
    [Route(ApisEndpoints.API_CONTROLLER)]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IAuthenticationService UserLoginRegisterService;

        public UserController(IAuthenticationService authenticationBusinessService)
        {
            UserLoginRegisterService = authenticationBusinessService;
        }

        [HttpPost(ApisEndpoints.REGISTER)]
        public IActionResult Register(RegisterRequest userRegister)
        {
          ApiResponse<RegisterResponse> response = UserLoginRegisterService.UserRegister(userRegister);
          return GenerateResponse(response);         
        }

        [HttpPost(ApisEndpoints.LOGIN)]
        public IActionResult Login(LoginRequest userLogin)
        {
            ApiResponse<LoginResponse> response = UserLoginRegisterService.UserLogin(userLogin);
            return GenerateResponse(response);
        }
    }
}