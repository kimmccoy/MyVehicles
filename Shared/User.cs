namespace Shared
{
    /// <summary>
    /// A user in the system
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique identifier for the user.
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// First name for the user.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Last name for the user.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// email address for the user.
        /// </summary>
        public required string Email { get; set; }
    }
}
