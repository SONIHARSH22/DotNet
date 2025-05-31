using Microsoft.IdentityModel.Tokens;
using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.Common.Constants;
using RestaurantManagement.Common.Enums;
using RestaurantManagement.Common.Helper;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;
using RestaurantManagement.DataService.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantManagement.BusinessService.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticatonDataService _authenticationDataService;
    private readonly IConfiguration configuration;

    public AuthenticationService(IAuthenticatonDataService userLoginRegisterDataService, IConfiguration configuration)
    {
        _authenticationDataService = userLoginRegisterDataService;
        this.configuration = configuration;
    }

 
    public ApiResponse<RegisterResponse> UserRegister(RegisterRequest userRegister)
    {
        try
        {
            Users? existingUser = _authenticationDataService.GetUserByEmail(userRegister.Email);
            if (existingUser != null)
            {
                return ApiResponse<RegisterResponse>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.USER_ALREADY_REGISTERED);
            }

            Roles? role = _authenticationDataService.GetRoleById(userRegister.Role);
            if (role == null)
            {
                return ApiResponse<RegisterResponse>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.INVALID_ROLEID);
            }

            Users newUser = new Users
            {
                Name = userRegister.Name,
                Email = userRegister.Email,
                Phone = userRegister.Phone,
                Password = "",
                RoleId = userRegister.Role,
                Roles = role,
                IsDeleted = false,
                EnrolledDateTime = DateTime.Now,
            };

            newUser.Password = PasswordHashing.HashPassword(newUser, userRegister.Password);

            _authenticationDataService.AddUser(newUser);

            RegisterResponse userRegisterResponse = new RegisterResponse
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email,
                Phone = newUser.Phone,
                Role = newUser.RoleId,
                Message = ReturnMessage.USER_REGISTERED_SUCCESSFULLY
            };

            return new ApiResponse<RegisterResponse>(ResponseCode.Ok, ReturnMessage.USER_REGISTERED_SUCCESSFULLY, userRegisterResponse);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return ApiResponse<RegisterResponse>.CreateResponse(ResponseCode.InternalServerError, ReturnMessage.ERROR_OCCURRED);
        }
    }

    public ApiResponse<LoginResponse> UserLogin(LoginRequest userLogin)
    {
        try
        {
            Users? existingUser = _authenticationDataService.GetUserByEmail(userLogin.Email);
            if (existingUser == null)
            {
                return ApiResponse<LoginResponse>.CreateResponse(ResponseCode.Unauthorized, ReturnMessage.INVALID_CREDENTIALS);
            }

            if (existingUser.Password == null || userLogin.Password == null)
            {
                return ApiResponse<LoginResponse>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.INVALID_CREDENTIALS);
            }

            bool isPasswordValid = PasswordHashing.VerifyPassword(existingUser, existingUser.Password, userLogin.Password);
            if (!isPasswordValid)
            {
                return ApiResponse<LoginResponse>.CreateResponse(ResponseCode.Unauthorized, ReturnMessage.INVALID_CREDENTIALS);
            }

            string token = GenerateJwtToken(existingUser);

            var response = new LoginResponse
            {
                Id = existingUser.Id,
                Name = existingUser.Name,
                Role = existingUser.RoleId,
                Token = token
            };

            return new ApiResponse<LoginResponse>(ResponseCode.Ok, ReturnMessage.LOGIN_SUCCESSFUL, response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return ApiResponse<LoginResponse>.CreateResponse(ResponseCode.InternalServerError, ReturnMessage.ERROR_OCCURRED);
        }
    }

    private string GenerateJwtToken(Users user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
        new Claim(ClaimTypes.Role, user.RoleId ?? string.Empty)
        };

        var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
            configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}