using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EHealth.Pages.Login
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            // This is a simple POST method for logout
            // You can add your cookie deletion and redirection logic here

            // For testing purposes, print a message to the console
            Response.Cookies.Delete("LoggedAccount");

            // Redirect to the login page or any other desired destination after logout
            return RedirectToPage("/Login/Login");
        }



        public IActionResult OnPostLogout(Boolean accepted)
        {
            // Delete the "LoggedAccount" cookie
            Response.Cookies.Delete("LoggedAccount");

            // Redirect to the login page or any other desired destination after logout
            return RedirectToPage("/Login/Login");
        }
    }
}
