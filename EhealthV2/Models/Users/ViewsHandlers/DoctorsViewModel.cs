// File: DoctorsViewModel.cs
using EhealthV2.Repositories.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EhealthV2.Models.Users.ViewsHandlers
{
    public class DoctorsViewModel : PageModel
    {

        private IDoctorsController _docdata;
        public DoctorsViewModel(IDoctorsController docdata)
        {
            _docdata = docdata;
        }
        public List<Doctors> DoctorsList { get; set; }

        public void OnGet(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                // No search term provided, retrieve all clinics
                DoctorsList = _docdata.DoctorsInitData();
            }
            else
            {
                // Use the search term to filter clinics
                DoctorsList = _docdata.DoctorsInitData();
            }
        }

    }
}