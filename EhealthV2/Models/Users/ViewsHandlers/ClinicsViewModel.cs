using EhealthV2.Repositories.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EhealthV2.Models.Users.ViewsHandlers
{
    public class ClinicsViewModel : PageModel
    {
        private IClinicsController _clinicdata;
        public ClinicsViewModel(IClinicsController clinicdata)
        {
            _clinicdata = clinicdata;
        }
        public List<Clinics> ClinicList { get; set; }
        public async Task OnGet(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                // No search term provided, retrieve all clinics
                //ClinicList = await _clinicdata.GetClinicsFromApi();
            }
            else
            {
                // Use the search term to filter clinics
                ClinicList = _clinicdata.SearchClinics(searchTerm);
            }
        }

    }
}
