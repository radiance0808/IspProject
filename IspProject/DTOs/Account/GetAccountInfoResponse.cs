namespace IspProject.DTOs.Account
{
    public class GetAccountInfoResponse
    {
        public double balance { get; set; }

        public string notificationType { get; set; }

        public string equipment { get; set; }

        public string package { get; set; }

        public bool isActive { get; set; }
    }
}
