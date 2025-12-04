namespace Shared
{

    /// <summary>
    /// Represents a vehicle registration as it would be in the database.
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// Unique identifier for the registration.
        /// </summary>
        public int RegistrationId { get; set; }

        /// <summary>
        /// Registration number of the vehicle, ie the licence plate.
        /// </summary>
        public required string RegistrationNumber { get; set; }

        /// <summary>
        /// Expiry date of the registration in UTC.
        /// </summary>
        public DateTime ExpiryDateUtc { get; set; }

        /// <summary>
        /// Unique identifier for the vehicle associated with this registration.
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// User identifier for the owner of the vehicle.
        /// </summary>
        public required string UserId { get; set; }
    }
}
