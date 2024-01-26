using EhealthV2.Models.Users;
using EhealthV2.Repositories.Login;
using EhealthV2.Repositories.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Text.Json;

namespace EhealthV2.Controllers
{
    public class LoginControllers : Controller
    {
        private ILoginController _LoginRepo;
        private IWebHostEnvironment _LoginEnv;

        public LoginControllers(ILoginController loginrepo, IWebHostEnvironment loginenv)
        {
            _LoginRepo = loginrepo;
            _LoginEnv = loginenv;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("LoginUser")]
         public IActionResult OnPostLogin(string Username, string Password)
        {
            //Check Username & Password With Api
            //
            // Check the login credentials (replace this with your actual logic)
            if (IsValidLogin(Username, Password))
            {
                Response.Cookies.Append("LoggedAccount", "true", new CookieOptions
                {
                    // Adjust other options if needed
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                });
                // Successful login
                return RedirectToPage("/Account/Index"); // Redirect to the home page or another page upon successful login
            }
            else
            {
                // Failed login
                ModelState.AddModelError(string.Empty, "Invalid login attempt. Please try again.");
                return null;
            }

            //Create Cookies if OK

            return RedirectToPage("/Index");
        }

        private bool IsValidLogin(string username, string password)
        {
            //Confirm Login With API

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                string response = _LoginRepo.GetUsersAsync(username).Result;
                Console.Write(response);
            }

            return false;
        }

    }
}
