using Microsoft.AspNetCore.Authorization;
using Shared;

namespace MyVehiclesWeb.Hubs
{
    /// <summary>
    /// Client interface for receiving vehicle registration updates via SignalR. This is what the client will implement
    /// to get updates from the server.
    /// </summary>
    public interface IRegoClient
    {
        /// <summary>
        /// Called with registration details that have been requested
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [AllowAnonymous]
        Task RegoDetailUpdate(RegistrationSummary? data);
    }
}
