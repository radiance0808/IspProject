namespace IspProject.Models
{
    public class Package
    {
    
        public int idPackage { get; set; }

        public string nameOfPackage { get; set; }

        public double price { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
