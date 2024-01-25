using EhealthV2.Models.Users;

namespace EhealthV2.Repositories.Users
{
    public interface IClinicsController
    {
      

        void AddClinic(string json);

        public List<Clinics> GetClinicsFromApi();

    }


}

