using RestaurantManagement.Models.Entity;

namespace RestaurantManagement.DataService.Interface
{
    public interface IAuthenticatonDataService
    {
        /// <summary>
        /// Retrieves user details based on their email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>The user details if found, otherwise null.</returns>
        Users? GetUserByEmail(string email);

        /// <summary>
        /// Retrieves role details based on the role ID.
        /// </summary>
        /// <param name="roleId">The ID of the role.</param>
        /// <returns>The role details if found, otherwise null.</returns>
        Roles? GetRoleById(string roleId);

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The user entity to be added.</param>
        void AddUser(Users user);
    }
}