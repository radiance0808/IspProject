namespace IspProject.Models
{
    public class Administrator
    {

        public int idUser { get; set; }
        public User User { get; set; }

        public virtual ICollection<SupportTicket> SupportTickets { get; set; }
    }
}