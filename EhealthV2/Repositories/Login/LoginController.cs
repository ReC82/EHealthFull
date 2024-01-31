using EhealthV2.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace EhealthV2.Repositories.Login
{
    public class LoginController : ILoginController
    {

        private HttpClient _httpClient = new HttpClient();

        public IActionResult Index()
        {
            return null;
        }

        public void Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetUsersAsync(string username)
        {
            // DEFINE API URL
            string apiUrl = "http://localhost:8080/getMyUser/" + username;

            try
            {
                // SEND A GET TO OBTAIN A JSON
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                // VERIFY THE STATUS
                response.EnsureSuccessStatusCode();

                // READ RESPONSES AS A STRING
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // RETURN THE STRING
                return jsonResponse;
            }
            catch (Exception ex)
            {
                // EXCEPTION HANDLER
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
