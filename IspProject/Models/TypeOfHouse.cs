namespace IspProject.Models
{
    public class TypeOfHouse
    {
        public int idTypeOfHouse { get; set; }

        public string typeOfHouse { get; set; }

        
        public virtual ICollection<Address> Addresses { get; set; }

    }
}
