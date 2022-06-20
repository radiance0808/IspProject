namespace IspProject.Models
{
    public class PotentialClient
    {

        public int idPotentialClient { get; set; }

        public string name { get; set; }

        public string phoneNumber { get; set; }

        public int idAddress { get; set; }

        public Address address { get; set; }
    }
}
