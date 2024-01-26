using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EhealthV2.Models.Users
{
    public class Doctors
    {
        [Key]
        public int DocId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        //public string Address { get; set; }

        //public string City { get; set; }

        //public string PostCode { get; set; }

        //public string Inami { get; set; }

        //public string Speciality { get; set; }

        //public string Organisation { get; set; }

    }

}
