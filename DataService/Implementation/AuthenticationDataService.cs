using RestaurantManagement.Models.Entity;
using RestaurantManagement.DataService.Interface;
using RestaurantManagement.Data.Context;

namespace RestaurantManagement.DataService.Implementation
{
    public class AuthenticationDataService : IAuthenticatonDataService
    {
        private readonly RestaurentManagementContext _restaurentManagementContext;
        private readonly IConfiguration _configuration;

        public AuthenticationDataService(RestaurentManagementContext context, IConfiguration configuration)
        {
            _restaurentManagementContext = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Retrieves user details based on the provided email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>The user details if found, otherwise null.</returns>
        public Users? GetUserByEmail(string email)
        {
            return _restaurentManagementContext.Set<Users>().FirstOrDefault(user => user.Email == email);
        }

        /// <summary>
        /// Retrieves role details based on the role ID.
        /// </summary>
        /// <param name="roleId">The ID of the role.</param>
        /// <returns>The role details if found, otherwise null.</returns>
        public Roles? GetRoleById(string roleId)
        {
            return _restaurentManagementContext.Set<Roles>().FirstOrDefault(role => role.RoleId == roleId);
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The user entity to be added.</param>
        public void AddUser(Users user)
        {
            _restaurentManagementContext.Set<Users>().Add(user);
            _restaurentManagementContext.SaveChanges();
        }
    }
}