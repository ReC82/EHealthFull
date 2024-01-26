using EhealthV2.Models.Users;
using EhealthV2.Repositories.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace EhealthV2.Controllers
{
    public class DoctorsControllers : Controller
    {
        private IDoctorsController _docRepo;
        private IWebHostEnvironment _docEnv;



        public DoctorsControllers(IDoctorsController repository, IWebHostEnvironment environment)
        {
            _docRepo = repository;
            _docEnv = environment;
        }

        /*public IActionResult ViewDoctorsList()
        {
            var doctors = _docRepo.DoctorsInitData();
            var viewModel = new DoctorsViewModel(_docRepo)
            {
                DoctorsList = doctors
            };

            return View(viewModel);
        }*/


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("AddDoctor")]
        public IActionResult AddDoctor(Doctors doctor)
        {
            if (ModelState.IsValid)
            {
                _docRepo.AddDoctor(doctor);
                return View("Pages/Signup/SignupConfirmation.cshtml");
            }
            return RedirectToPage("/Index");
        }
    }
}
