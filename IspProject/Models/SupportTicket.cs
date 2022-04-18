namespace IspProject.Models
{
    public class SupportTicket
    {

        public int idSupportTicket { get; set; }

        public string topic { get; set;}
        
        public string message { get; set;}

        public DateTime dateOfCreation { get; set; }

        public string status { get; set; }

        public bool isFinished { get; set; }

        public DateTime updatedAt { get; set; }

        public int idAdministrator { get; set; }

        public int idUser { get; set; }

        public Administrator Administrator { get; set; }
        
        public Account account { get; set; }

        


    }
}