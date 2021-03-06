namespace IspProject.Models
{
    public class PotentialClient
    {

        public int idPotentialClient { get; set; }

        public string name { get; set; }

        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string email { get; set; }

        public int idPackage { get; set; }
        public int idTypeOfHouse { get; set; }

        public Package package { get; set; }
        public TypeOfHouse typeOfHouse { get; set; }
    }
}
