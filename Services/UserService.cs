using Shared;

namespace Services
{
    public class UserService : IUserService
    {
        private MockData _mockData;

        public UserService()
        {
            _mockData = MockData.Instance;
        }

        /// <summary>
        /// Gets a user by their unique identifier.
        /// </summary>
        /// <param name="userId">User id (Guid)</param>
        /// <returns></returns>
        public async Task<User?> GetByIdAsync(string userId)
        {
            // Implementation to retrieve user by ID
            return _mockData.Users.FirstOrDefault(x => x.UserId == userId);
        }

        /// <summary>
        /// Gets a user by their email address.
        /// </summary>
        /// <param name="email">Email address to search for. Case insensitive</param>
        /// <returns></returns>
        public async Task<User?> GetByEmailAsync(string email)
        {
            // Implementation to retrieve user by Email
            return _mockData.Users.FirstOrDefault(x => string.Equals(x.Email, email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
