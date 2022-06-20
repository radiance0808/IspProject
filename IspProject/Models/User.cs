namespace IspProject.Models
{
    public class User
    {

        public int idUser { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string login { get; set; }
        
        public string password { get; set; }             

        public string phoneNumber { get; set; }

        public string emailAdress { get; set; }

        public string passportId { get; set; }

        public string Role { get; set; }

        public string Refreshtoken { get; set; }
        public DateTime? Refreshtokenexp { get; set; }

        public Account account { get; set; }

        public virtual ICollection<SupportTicket> SupportTickets { get; set; }

    }
}
