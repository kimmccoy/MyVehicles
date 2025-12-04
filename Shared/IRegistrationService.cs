

namespace Shared
{
    /// <summary>
    /// Provides access to registration data.
    /// </summary>
    public interface IRegistrationService
    {
        /// <summary>
        /// Get a registration by its identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RegistrationSummary? Get(int id);

        /// <summary>
        /// Get all registrations by vehicle identifier. May be zero more results.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<RegistrationSummary> GetByVehicle(int id);
    }
}