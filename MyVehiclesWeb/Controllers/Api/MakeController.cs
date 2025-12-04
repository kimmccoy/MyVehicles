using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Shared;

namespace MyVehiclesWeb.Controllers.Api
{
    /// <summary>
    /// Provides access to vehicle makes (manufacturers brand names).
    /// </summary>
    [ApiController]
    public class MakeController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public MakeController(IVehicleService vehicleService)
        {
            this._vehicleService = vehicleService;
        }


        // for POST / DELETE / PUT, not GET, OPTIONS
        //[ValidateAntiForgeryToken]

        /// <summary>
        /// Returns a list of all known vehicle makes
        /// </summary>
        /// <returns>An enumerable collection of <see cref="AccountVehicleRegistration"/> objects for the specified user. The collection
        /// will be empty if the user has no vehicle registrations.</returns>
        [Authorize()]
        [Route("api/makes")]
        [HttpGet]
        public IEnumerable<string> GetMakes()
        {
            return _vehicleService.GetMakes();
        }


    }
}
