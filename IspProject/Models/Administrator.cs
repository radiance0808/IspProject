namespace IspProject.Models
{
    public class Administrator
    {

        public int idAdministrator { get; set; }
        public int idUser { get; set; }
        public User User { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public virtual ICollection<SupportTicket> SupportTickets { get; set; }
    }
}