using System.ComponentModel.DataAnnotations;

namespace IspProject.DTOs
{
    public class CreatePotentialClientRequest
    {

        [Required]
        public string name { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public int idPackage { get; set; }
        [Required]
        public int idTypeOfHouse { get; set; }
    }
}
