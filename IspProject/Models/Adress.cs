namespace IspProject.Models
{
    public class Adress
    {

        public int idAdress { get; set; }

        public string adress { get; set; }

        public int idTypeOfHouse { get; set; }

        public TypeOfHouse typeOfHouse { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<PotentialClient> PotentialClients { get; set; }
    }
}