using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyVehiclesWeb.Controllers.Mvc
{
    /// <summary>
    /// Basic controller to serve the main application page.
    /// </summary>
    public class HomeController : Controller
    {

        /// <summary>
        /// Default action to serve the main application page.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult Index()
        {
            // Add no caching headers to prevent caching of the main page   
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            // Serve the main application page for the Angular app at the root of the site
            return PhysicalFile(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dist", "index.html"),
                "text/HTML"
            );
        }
    }
}
