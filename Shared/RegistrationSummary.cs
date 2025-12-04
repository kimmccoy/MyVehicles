namespace Shared
{

    /// <summary>
    /// Summary information about a vehicle registration.
    /// </summary>
    public class RegistrationSummary
    {
        /// <summary>
        /// Unique identifier for a registration.
        /// </summary>
        public int RegistrationId { get; set; }

        /// <summary>
        /// Registration number (licence plate) of the vehicle.
        /// </summary>
        public required string RegistrationNumber { get; set; }

        /// <summary>
        /// Expiration date and time in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime ExpiryDateUtc { get; set; }

        /// <summary>
        /// Unique identifier for the vehicle associated with this registration.
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Unique identifier for the user who owns the vehicle.
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// True if the registration has expired; otherwise, false. This is calculated on the server 
        /// as client times may be inaccurate.
        /// </summary>
        public bool IsExpired => ExpiryDateUtc < DateTime.UtcNow;
    }
}
