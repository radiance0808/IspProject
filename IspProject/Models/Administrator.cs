namespace IspProject.Models
{
    public class Administrator
    {

        public User User { get; set; }

        public virtual ICollection<SupportTicket> SupportTickets { get; set; }
    }
}