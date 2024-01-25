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

        public List<Doctors> DoctorsInitData()
        {
            return _context.Doctors.ToList();
            //return new List<Doctors>(); // or throw an exception, depending on your application's requirements        
        }

        /*public List<Doctors> GetDoctors()
        {
            return _context.Doctors.ToList();
        }*/



    }
}
