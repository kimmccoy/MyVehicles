using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Services;
using Shared;

namespace MyVehiclesWeb.Hubs
{

    /// <summary>
    /// SignalR hub for vehicle registration updates.
    /// </summary>
    /// <remarks>
    /// Use cookie authentication to ensure only authenticated users can access this method.
    /// Can extend to tokens if needed to support other clients like mobile apps.
    /// </remarks>
    public class RegoHub : Hub<IRegoClient>
    {
        private readonly IRegistrationService _registrationService;

        public RegoHub(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        /// <summary>
        /// Called by the client to request the rego status for a vehicle.
        /// </summary>
        /// <param name="vehicleId">Id of the vehicle to do a rego check for</param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task RegoStatusInquiry(int vehicleId)
        {
            // Get the registration details from the service
            // and only get the most recent one
            var regoDetails = _registrationService.GetByVehicle(vehicleId)
                .OrderByDescending(x=>x.ExpiryDateUtc).FirstOrDefault();

            // Send the details back to the caller only
            await Clients.Caller.RegoDetailUpdate(regoDetails);
        }


        public override async Task OnConnectedAsync()
        {
            // Log so we can see what is going on (would use a proper logger in real code)
            Console.WriteLine(Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            // Log so we can see what is going on  (would use a proper logger in real code)
            Console.WriteLine(Context.ConnectionId);
            await base.OnDisconnectedAsync(ex);
        }
    }
}
