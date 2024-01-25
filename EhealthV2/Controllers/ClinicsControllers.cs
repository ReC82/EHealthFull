using EhealthV2.Models.Users;
using EhealthV2.Repositories.Users;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EhealthV2.Controllers
{
    public class ClinicsControllers : Controller
    {
        private IClinicsController _clinicRepo;
        private IWebHostEnvironment _clinicEnv;

        public ClinicsControllers(IClinicsController repository, IWebHostEnvironment environment)
        {
            _clinicRepo = repository;
            _clinicEnv = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("AddClinic")]
        public IActionResult AddClinic(Clinics clinic)
        {
            if (ModelState.IsValid)
            {
                //Add logic to json
                string clinicStr = JsonSerializer.Serialize(clinic);
                //string clinicJson = _clinicRepo.ConvertDataToJson(clinicStr);
                _clinicRepo.AddClinic(clinicStr);
                return View("Pages/Signup/SignupConfirmation.cshtml");
            }
            return RedirectToPage("/Index");
        }




    }
}
