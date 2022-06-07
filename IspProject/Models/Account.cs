namespace IspProject.Models
{
    public class Account
    {

        public int idAccount { get; set; }
        public int idUser { get; set; }

        public User user { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public double balance { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public int idPackage { get; set; }

        public int idAdress { get; set; }

        public Package Package { get; set; }

        public Adress Adress { get; set; }

        public int idEquipment { get; set; }
        
        public Equipment Equipment { get; set; }

        public NotificationType NotificationType { get; set; }

        public virtual ICollection<Traffic> Traffics { get; set; }

        public virtual ICollection<Account_AdditionalService> Account_AdditionalServices { get; set; }

        public virtual ICollection<SupportTicket> SupportTickets { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }



    }
}
