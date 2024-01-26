using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EHealth.Pages.Login
{
    public class LoginModel : PageModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(string Username, string Password)
        {
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
                return Page();
            }
        }

        private bool IsValidLogin(string username, string password)
        {
            // Gets Acount from csv
            // Read the CSV file and check if the provided credentials exist
            string usersFilePath = "wwwroot/csv/users.csv"; // Replace with the actual path to your CSV file

            // Read all lines from the CSV file
            string[] lines = System.IO.File.ReadAllLines(usersFilePath);

            foreach (string line in lines.Skip(1)) // Skip header line if present
            {
                string[] values = line.Split(',');

                // Assuming CSV structure: username,password
                string storedId = values[0];
                string storedUsername = values[1];
                string storedPassword = values[2];
                string storedLastLoginDate= values[3];

                // Check if provided credentials match any entry in the CSV file
                if (username == storedUsername && password == storedPassword)
                {
                    return true; // Credentials found
                }
            }

            return false;
        }

    }
}
