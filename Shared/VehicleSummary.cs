namespace Shared
{

    /// <summary>
    /// Summary information about a vehicle. A vehicle can have multiple registrations over time.
    /// </summary>
    public class VehicleSummary
    {
        /// <summary>
        /// The user who owns the vehicle.
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// Unique identifier for the vehicle.
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Unique identifier for the registration.
        /// </summary>
        public int RegistrationId { get; set; }

        /// <summary>
        /// Make of the vehicle such as Toyota, Ford, etc.
        /// </summary>
        public required string Make { get; set; }

        /// <summary>
        /// Model name of the vehicle such as Camry, Mustang, etc.
        /// </summary>
        public required string Model { get; set; }

        /// <summary>
        /// Year of compliance of the vehicle.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The current registration number for the vehicle.
        /// </summary>
        public string CurrentRegistrationNumber { get; set; } = string.Empty;
    }
}
