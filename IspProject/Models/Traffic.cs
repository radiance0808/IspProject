namespace IspProject.Models
{
    public class Traffic
    {
        public int idTraffic { get; set; }

        public string application { get; set; }

        public double consumptedTraffic { get; set; }

        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public int idUser;

        public Account account;

    }
}
