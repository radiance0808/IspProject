namespace IspProject.Models
{
    public class Address
    {

        public int idAddress { get; set; }

        public string address { get; set; }

        public int idTypeOfHouse { get; set; }

        public TypeOfHouse typeOfHouse { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<PotentialClient> PotentialClients { get; set; }
    }
}