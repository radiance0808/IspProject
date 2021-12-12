namespace IspProject.Models
{
    public class Account
    {
        public User user { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public double balance { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public Package Package { get; set; }

        public Adress Adress { get; set; }

        public virtual ICollection<Traffic> Traffics { get; set; }

        public virtual ICollection<Account_AdditionalService> Account_AdditionalServices { get; set; }

        public virtual ICollection<SupportTicket> SupportTickets { get; set; }



    }
}
