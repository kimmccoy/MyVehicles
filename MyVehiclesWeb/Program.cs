
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;
using Shared;

namespace MyVehiclesWeb
{
    public class Program
    {
        /// <summary>
        /// Main startup. 
        /// This is all in the one file as it's fairly simple, but should be split up if the project needs more configuration.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IUserService, Services.UserService>();
            builder.Services.AddScoped<IVehicleService, Services.VehicleService>();
            builder.Services.AddScoped<IRegistrationService, Services.RegistrationService>();

            // Add SignalR services
            builder.Services.AddSignalR(options =>
            {
                // TODO: configure different options if development or production
                options.EnableDetailedErrors = true;
                options.MaximumReceiveMessageSize = 1024000; // 1 MB
            });


            // Add API controllers
            builder.Services.AddControllers();

            // Configure antiforgery to use a custom header name that is used by Angular by default
            builder.Services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            // Add OpenApi documentation generation for use with Scalar
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddOpenApi(options =>
                {
                    // configuring OpenAPI at https://aka.ms/aspnet/openapi
                });
            }

            // Configure Cookie Authentication
            // This is used to authenticate users for the web app and SignalR hub
            // to ensure that CRSF protection works correctly and bearer tokens are not needed
            // as they can get read from the browser by malicious scripts.
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    if (builder.Environment.IsProduction())
                    {
                        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                        options.Cookie.SameSite = SameSiteMode.Strict;
                    }
                    else
                    {
                        // angular dev server runs on different port so need to allow cross-site cookies
                        options.Cookie.SameSite = SameSiteMode.None;
                    }
                });

            // Add razor pages for MVC views
            builder.Services.AddRazorPages();

            // Add MVC controllers, views
            builder.Services.AddControllersWithViews(options =>
            {
                //  with antiforgery token validation globally for all unsafe methods
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            // Configure CORS for development to allow Angular dev server access if needed
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                }));
            }

            var app = builder.Build();

            // Log all requests to the console in development. To see what Angular is doing
            if (app.Environment.IsDevelopment())
            {
                app.Use(async (context, next) =>
            {
                var request = context.Request;
                Console.WriteLine($"{request.Method}: {request.GetEncodedPathAndQuery()}");
                await next.Invoke();

            });
            }

            // Enable antiforgery middleware
            app.UseAntiforgery();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                // Cookies not working https://github.com/scalar/scalar/issues/3701
                app.MapScalarApiReference(options =>
                {
                    options.Title = "Vehicle Licencing API";
                });
            }

            if (app.Environment.IsDevelopment())
            {
                // Disable CORS as the Angular app will be running in development on a different port
                app.UseCors("MyPolicy");
            }

            // Only use HTTPS
            app.UseHttpsRedirection();

            // Enable routing
            app.UseRouting();

            // Enable authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Provide the XSRF token as a cookie for API use from Angular
            // TODO: the angular app isn't doing any POST/PUT/DELETE so it isn't using this yet
            app.MapGet("antiforgery/token", (IAntiforgery forgeryService, HttpContext context) =>
            {
                var tokens = forgeryService.GetAndStoreTokens(context);
                context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!,
                        new CookieOptions { HttpOnly = false });

                return Results.Ok();
            }).RequireAuthorization();

            // Serve static files for Angular app located at wwwroot/dist
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Map API controllers
            app.MapControllers();

            // Setup MVC routes
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();


            app.MapRazorPages()
                .WithStaticAssets();

            // Configure SignalR hubs
            app.MapHub<Hubs.RegoHub>("/hubs/rego");

            app.Run();
        }
    }
}
