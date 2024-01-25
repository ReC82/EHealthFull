using EhealthV2.Data;
using EhealthV2.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Numerics;

namespace EhealthV2.Repositories.Users
{
    public class DoctorsController : IDoctorsController
    {
        private DoctorsContext _context;
        private readonly HttpClient httpClient = new HttpClient();
        public DoctorsController(DoctorsContext context)
        {
            _context = context;
        }
        public void AddDoctor(Doctors Doctor)
        {
            // EXECUTE ADD FUNCTION
            _context.Add(Doctor);
        }

        public void DeleteDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public List<Doctors> DoctorsInitData()
        {
            return _context.Doctors.ToList();
            //return new List<Doctors>(); // or throw an exception, depending on your application's requirements        
        }

        public IEnumerable<Doctors> GetAllDoctors()
        {
            //NOT IMPLEMENTED YET
            throw new NotImplementedException();
        }

        public Doctors GetDoctorsById(int id)
        {
            //NOT IMPLEMENTED YET
            throw new NotImplementedException();
        }

        public void saveChanges()
        {
            //NOT IMPLEMENTED YET
            throw new NotImplementedException();
        }

        public string getJsonFromEclipse()
        {
            // HTTP CLIENT SETTINGS
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // GET RESPONSE FROM GetJsonAsync FUNCTION
            Task<String> response = GetJsonAsync();

            //response.Result.ToString();

            // RETURN RESPONSE TO STRING
            return response.Result.ToString();       
        }

    }
}
