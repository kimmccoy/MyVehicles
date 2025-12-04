
namespace Shared
{
    /// <summary>
    /// Provides access to vehicle data.
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// Gets a vehicle by id. Returns null if not found.
        /// </summary>
        /// <param name="id">Id of the vehicle</param>
        /// <returns></returns>
        VehicleSummary? Get(int id);

        /// <summary>
        /// Retrieves a collection of vehicle summaries associated with the specified user, optionally filtered by
        /// vehicle make.
        /// </summary>
        /// <param name="userId">The unique identifier of the user whose vehicles are to be retrieved. Cannot be null.</param>
        /// <param name="make">An optional vehicle make to filter the results. If null or whitespace, all makes are included.</param>
        /// <returns>An enumerable collection of vehicle summaries for the specified user. The collection is empty if no vehicles
        /// match the criteria.</returns>
        IEnumerable<VehicleSummary> GetByUser(string userId, string? make);

        /// <summary>
        /// Returns a list of known vehicle makes like Toyota, Honda, BMW
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetMakes();
    }
}