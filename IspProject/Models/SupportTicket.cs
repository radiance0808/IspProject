namespace IspProject.Models
{
    public class SupportTicket
    {

        public int idSupportTicket { get; set; }

        public string topic { get; set;}
        
        public string question { get; set;}
        
        public string answer { get; set;}

        public DateTime dateOfCreation { get; set; }

        public string status { get; set; }

        public bool isFinished { get; set; }

        public DateTime updatedAt { get; set; }

        public int? idUser { get; set; }

       
        
        
        public User user { get; set; }

        


    }
}