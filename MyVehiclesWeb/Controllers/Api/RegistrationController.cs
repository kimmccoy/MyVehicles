using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Shared;
using System.Security.Claims;

namespace MyVehiclesWeb.Controllers.Api
{
    
    /// <summary>
    /// Handles registration related operations for vehicles.
    /// </summary>
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            this._registrationService = registrationService;
        }

        // for POST / DELETE / PUT, not GET, OPTIONS
        //[ValidateAntiForgeryToken]

        [Authorize]
        [Route("api/registrations/{id:int}")]
        [HttpGet]
        public IEnumerable<RegistrationSummary> Get(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var items = _registrationService.GetByVehicle(id);

            // Ensure the user only gets their own registrations

            // TODO: map to types that are suitable for returning via the public API
            // rather than internal domain types
            return items.Where(r => r.UserId == userId);
        }
    }
}
