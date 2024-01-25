using EhealthV2.Data;
using EhealthV2.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EhealthV2.Repositories.Users
{
    public class ClinicController : IClinicsController
    {

        private DoctorsContext _context;
        private readonly HttpClient httpClient = new HttpClient();
        public string ConvertDataToJson(string json)
        {
            return null;
        }

        public string getJsonFromEclipse()
        {
            throw new NotImplementedException();
        }

        public void AddClinic(string json)
        {
            PostDataToEclipseAsync(json);
        }

        public async Task<string> PostDataToEclipseAsync(string json)
        {
            // Define the API endpoint for posting data
            string apiUrl = "http://localhost:8080/saveClinic";

            try
            {
                // Send a POST request with JSON data
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                // Read the response content as string
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Output the JSON response (optional)
                Console.WriteLine("API Response Content:");
                Console.WriteLine(jsonResponse);

                return jsonResponse;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
        public void Dispose()
        {
            httpClient.Dispose();
        }

        public async Task<string> GetJsonAsync()
        {
            // DEFINE API URL
            string apiUrl = "http://localhost:8080/getClinics";

            try
            {
                // SEND A GET TO OBTAIN A JSON
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

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
