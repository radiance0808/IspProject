namespace IspProject.Models
{
    public class User
    {

        public int idUser { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string phoneNumber { get; set; }

        public string emailAdress { get; set; }

        public string passportId { get; set; }

        public Account account { get; set; }

        public Administrator administrator { get; set; }
    }
}
