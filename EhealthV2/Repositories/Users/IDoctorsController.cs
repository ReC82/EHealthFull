using EhealthV2.Models;
using EhealthV2.Models.Users;
using System.Numerics;

namespace EhealthV2.Repositories.Users
{
    public interface IDoctorsController
    {

        void AddDoctor(Doctors Doctor);

        List<Doctors> DoctorsInitData();

        //public List<Doctors> GetDoctors();
    }
}
