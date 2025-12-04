using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Services;
using Shared;
using System.Security.Claims;
using MyVehiclesWeb.Views.Account;

namespace MyVehiclesWeb.Controllers.Mvc
{
    /// <summary>
    /// Handles user account related actions such as login and logout.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Display the login page
        /// </summary>
        /// <returns></returns>

        public IActionResult Login()
        {
            // There's only one user in the system to prefill for this demo
            var model = new LoginViewModel
            {
                Email = "b.ross@example.com"
            };
            return View(model);
        }

        /// <summary>
        /// Log the user in using Cookie Authentication
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Login here using custom cookie authentication. In practice this is not great,
            // and would use ASP.NET Core Identity or another library.

            if (ModelState.IsValid)
            {
                var user = await _userService.GetByEmailAsync(model.Email ?? "");

                // not checking the password - this is just a demo
                if (user != null)
                {
                    // Create claims and authenticate the user
                    var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.NameIdentifier, user.UserId),
                                new Claim(ClaimTypes.Name, user.Email),
                                new Claim(ClaimTypes.Email, user.Email),
                                // Add any additional claims as needed...
                            };

                    // Create the identity and principal
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Set authentication properties. Here we set IsPersistent to true to create a persistent cookie.
                    // as in the 'RememberMe' functionality.
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddDays(7)
                    };

                    // Sign in the user
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    // Go to the home page which will be the Angular SPA
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check your username and password");
            }

            return View(model);
        }


        /// <summary>
        /// Logout the current user
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            // Clear the user's session. Not currently using sessions.
            //HttpContext.Session.Clear();

            // Sign out to remove the authentication cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect to the login page or home page
            return RedirectToAction("Index", "Home");
        }
    }
}
