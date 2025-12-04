namespace Shared
{
    /// <summary>
    /// A vehicle in the system. A vehicle can have multiple registrations over time.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Unique identifier for the vehicle.
        /// </summary>
        public int VehicleId { get; set; }

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
        /// Colour of the vehicle.
        /// </summary>
        public required string Colour { get; set; }

        /// <summary>
        /// Manufacturer's VIN (Vehicle Identification Number) for the vehicle.
        /// </summary>
        public required string VIN { get; set; }

        /// <summary>
        /// Engine number of the vehicle. May change over time.
        /// </summary>
        public string? EngineNumber { get; set; }

    }
}
