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
        public List<Doctors> DoctorsList { get; set; }
        public DoctorsController(DoctorsContext context)
        {
            _context = context;
            DoctorsList = DoctorsInitData();
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

        public List<Doctors> SearchDoctors(string searchTerm)
        {
            if (DoctorsList == null)
            {
                // Handle the case where DoctorsList is null, log, throw an exception, etc.
                return new List<Doctors>();
            }

            var filteredDoctors = DoctorsList
                .Where(doctor =>
                    (doctor.FirstName?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false)) 
                    //(doctor.LastName?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    //(doctor.Address?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    //(doctor.Speciality?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    //(doctor.Email?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false))
                .ToList();

            return filteredDoctors;
        }

        /*public List<Doctors> GetDoctors()
        {
            return _context.Doctors.ToList();
        }*/



    }
}
