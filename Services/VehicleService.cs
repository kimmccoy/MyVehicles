

using Shared;

namespace Services
{
    /// <summary>
    /// Implements the IVehicleService interface using mock data.
    /// </summary>
    public class VehicleService : IVehicleService
    {
        public VehicleService() { }


        /// <summary>
        /// Retrieves a collection of vehicle summaries associated with the specified user, optionally filtered by
        /// vehicle make.
        /// </summary>
        /// <param name="userId">The unique identifier of the user whose vehicles are to be retrieved. Cannot be null.</param>
        /// <param name="make">An optional vehicle make to filter the results. If null or whitespace, all makes are included.</param>
        /// <returns>An enumerable collection of vehicle summaries for the specified user. The collection is empty if no vehicles
        /// match the criteria.</returns>
        public IEnumerable<VehicleSummary> GetByUser(string userId, string? make)
        {
            var mockData = MockData.Instance;

            var results = new List<VehicleSummary>();

            foreach (var registration in mockData.Registrations)
            {
                if (registration.UserId == userId)
                {
                    var vehicle = mockData.Vehicles.FirstOrDefault(v => v.VehicleId == registration.VehicleId);
                    if (vehicle != null && (string.IsNullOrWhiteSpace(make) || vehicle.Make.Equals(make?.Trim(), StringComparison.OrdinalIgnoreCase)))
                    {
                        results.Add(new VehicleSummary
                        {
                            UserId = userId,
                            VehicleId = vehicle.VehicleId,
                            RegistrationId = registration.RegistrationId,
                            Make = vehicle.Make,
                            Model = vehicle.Model,
                            Year = vehicle.Year,
                            CurrentRegistrationNumber = registration.RegistrationNumber
                        });
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Gets a vehicle by id. Returns null if not found.
        /// </summary>
        /// <param name="id">Id of the vehicle</param>
        /// <returns></returns>
        public VehicleSummary? Get(int id)
        {
            var mockData = MockData.Instance;

            foreach (var registration in mockData.Registrations)
            {
                if (registration.VehicleId == id)
                {
                    var vehicle = mockData.Vehicles.FirstOrDefault(v => v.VehicleId == registration.VehicleId);
                    if (vehicle != null)
                    {
                        return new VehicleSummary
                        {
                            UserId = registration.UserId,
                            VehicleId = vehicle.VehicleId,
                            RegistrationId = registration.RegistrationId,
                            Make = vehicle.Make,
                            Model = vehicle.Model,
                            Year = vehicle.Year,
                            CurrentRegistrationNumber = registration.RegistrationNumber
                        };
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a list of known vehicle makes like Toyota, Honda, BMW
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetMakes()
        {
            var mockData = MockData.Instance;

            var results = mockData.Vehicles.Select(x => x.Make).Distinct().Order();

            return results;
        }

    }
}
