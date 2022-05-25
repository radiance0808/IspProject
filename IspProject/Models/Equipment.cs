namespace IspProject.Models
{
    public class Equipment
    {
        public int idEqupment { get; set; }

        public string routerName { get; set; }

        public string description { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }


    }
}
