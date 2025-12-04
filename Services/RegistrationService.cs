

using Shared;

namespace Services
{
    /// <summary>
    /// Provides access to registration data.
    /// </summary>
    public class RegistrationService : IRegistrationService
    {

        /// <summary>
        /// Get a registration by its identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RegistrationSummary? Get(int id)
        {
            var mockData = MockData.Instance;
            return mockData.Registrations
                .Where(r => r.RegistrationId == id)
                .Select(r => new RegistrationSummary()
                {
                    RegistrationNumber = r.RegistrationNumber,
                    ExpiryDateUtc = r.ExpiryDateUtc,
                    RegistrationId = r.RegistrationId,
                    UserId = r.UserId,
                    VehicleId = r.VehicleId

                })
                .FirstOrDefault();
        }

        /// <summary>
        /// Get all registrations by vehicle identifier. May be zero more results.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<RegistrationSummary> GetByVehicle(int id)
        {
            var mockData = MockData.Instance;
            return mockData.Registrations
                .Where(r => r.VehicleId == id)
                .Select(r => new RegistrationSummary()
                {
                    RegistrationNumber = r.RegistrationNumber,
                    ExpiryDateUtc = r.ExpiryDateUtc,
                    RegistrationId = r.RegistrationId,
                    UserId = r.UserId,
                    VehicleId = r.VehicleId

                });
        }
    }
}
