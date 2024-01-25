using System.ComponentModel.DataAnnotations;

namespace EhealthV2.Models.Users
{
    public class Clinics : WebUsers
    {
        [Key]
        public int clinicId { get; set; }

        public string clinicName { get; set; }

        public string clinicAddress { get; set; }

        public string clinicAddressNumber { get; set; }

        public string clinicPostalCode { get; set; }

        public string clinicCity { get; set; }

        public string clinicEmail { get; set; }

        public string clinicPhone { get; set; }

        public string clinicInami{ get; set; }
    }
}
