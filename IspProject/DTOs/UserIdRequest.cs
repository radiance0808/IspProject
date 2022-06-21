using System.ComponentModel.DataAnnotations;

namespace IspProject.DTOs
{
    public class UserIdRequest
    {
        [Required]
        public int idUser { get; set; }
    }
}
