using EhealthV2.Models;
using EhealthV2.Models.Users;
using System.Numerics;

namespace EhealthV2.Repositories.Users
{
    public interface IDoctorsController
    {
        IEnumerable<Doctors> GetAllDoctors();

        Doctors GetDoctorsById(int id);

        void AddDoctor(Doctors Doctor);

        void DeleteDoctor(int id);
        void saveChanges();

        List<Doctors> DoctorsInitData();


    }
}
