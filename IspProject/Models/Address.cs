namespace IspProject.Models
{
    public class Address
    {

        public int idAddress { get; set; }

        public string city { get; set; }
        public string street { get; set; }
        public string houseNumber { get; set; }
        public string apartmentNumber { get; set; }

        public int idTypeOfHouse { get; set; }

        public TypeOfHouse typeOfHouse { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<PotentialClient> PotentialClients { get; set; }
    }
}