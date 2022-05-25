namespace IspProject.Models
{
    public class PotentialClient
    {

        public int idPotentialClient { get; set; }

        public string name { get; set; }

        public string phoneNumber { get; set; }

        public int idAdress { get; set; }

        public Adress adress { get; set; }
    }
}
