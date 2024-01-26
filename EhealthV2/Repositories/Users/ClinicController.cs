using EhealthV2.Data;
using EhealthV2.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Bogus;
using EhealthV2.Controllers;
using System.Net.Http;

namespace EhealthV2.Repositories.Users
{
    public class ClinicController : Controller, IClinicsController
    {
        private DoctorsContext _context;

        private HttpClient _httpClient = new HttpClient();
        public List<Clinics> ClinicsList { get; set; }

        public void AddClinic(string json)
        {
            string PostClinicApiUrl = "http://localhost:8080/saveClinic";
            PostDataToEclipseAsync(json, PostClinicApiUrl);
            //ClinicsList = GetClinicsFromApi();
        }

        public async Task<string> PostDataToEclipseAsync(string json, string apiUrl)
        {
            // Define the API endpoint for posting data
            try
            {
                // Send a POST request with JSON data
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, new StringContent(json, Encoding.UTF8, "application/json"));

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
            _httpClient.Dispose();
        }

        public async Task<string> GetJsonAsync()
        {
            // DEFINE API URL
            string apiUrl = "http://localhost:8080/getClinics";

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

        public List<Clinics> GetClinicsFromApi()
        {
            // Get Clinics From API
            List<Clinics> List = ConvertJsonStringToList<Clinics>(GetJsonAsync().ToString());
            return List;
        }

        // Function to convert JSON string to List<T>
        static List<T> ConvertJsonStringToList<T>(string jsonString)
        {
            // Deserialize JSON string to List<T>
            List<T> resultList = JsonConvert.DeserializeObject<List<T>>(jsonString);

            return resultList;
        }

        public List<Clinics> SearchClinics(string searchTerm)
        {
            return null;
        }
    }
}
