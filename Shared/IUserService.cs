
namespace Shared
{
    /// <summary>
    /// Provides access to user data.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets a user by their email address.
        /// </summary>
        /// <param name="email">Email address to search for. Case insensitive</param>
        /// <returns></returns>
        Task<User?> GetByEmailAsync(string email);

        /// <summary>
        /// Gets a user by their unique identifier.
        /// </summary>
        /// <param name="userId">User id (Guid)</param>
        /// <returns></returns>
        Task<User?> GetByIdAsync(string userId);
    }
}