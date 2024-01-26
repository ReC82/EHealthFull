using EhealthV2.Repositories.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EhealthV2.Models.Users.ViewsHandlers
{
    public class LoginViewModel : PageModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public LoginController login;

        public void OnGet()
        {
        }



        [HttpPost, ActionName("LoginUser")]
        public IActionResult LoginUser()
        {

            return Page();
        }

    }
}
