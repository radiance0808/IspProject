using IspProject.Models;
using System.ComponentModel.DataAnnotations;

namespace IspProject.DTOs.Account
{
    public class CreateAccountRequest
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string login { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string phoneNumber { get; set; }

        [Required]
        public string emailAddress { get; set; }

        [Required]
        public string passportId { get; set; }

        [Required]
        public int idPackage { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string street { get; set; }

        [Required]
        public string houseNumber { get; set; }

        [Required]
        public string apartmentNumber { get; set; }

        [Required]
        public int idTypeOfHouse { get; set; }

        [Required]
        public int idEquipment { get; set; }

        [Required]
        public NotificationType notificationType { get; set; }
    }
}
