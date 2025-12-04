using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Shared;
using System.Security.Claims;

namespace MyVehiclesWeb.Controllers.Api
{
    /// <summary>
    /// Provides endpoints for managing and retrieving vehicle-related data for authenticated users.
    /// </summary>
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // for POST / DELETE / PUT, not GET, OPTIONS
        //[ValidateAntiForgeryToken]

        /// <summary>
        /// Retrieves the collection of vehicle registrations associated with the specified user.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="AccountVehicleRegistration"/> objects for the specified user. The collection
        /// will be empty if the user has no vehicle registrations.</returns>
        [Authorize()]
        [Route("api/vehicles")]
        [HttpGet]
        public IEnumerable<VehicleSummary> GetByMake(string? make)
        {
            // TODO: map to types that are suitable for returning via the public API
            // rather than internal domain types
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _vehicleService.GetByUser(userId ?? "", make);
        }


        /// <summary>
        /// Retrieves the summary details of a vehicle by its unique identifier.
        /// </summary>
        /// <remarks>This method requires the caller to be authenticated. The vehicle will only be
        /// returned if it is associated  with the currently authenticated user.</remarks>
        /// <param name="id">The unique identifier of the vehicle to retrieve.</param>
        [Authorize()]
        [Route("api/vehicles/{id:int}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VehicleSummary> Get(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
           
            var vehicle = _vehicleService.Get(id);

            // TODO: map to types that are suitable for returning via the public API
            // rather than internal domain types
            return (vehicle == null || vehicle.UserId != userId) ? NotFound() : vehicle;
           
        }

    }
}
