﻿using IspProject.Models;

namespace IspProject.DTOs
{
    public class UserCreationDTO
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string phoneNumber { get; set; }

        public string emailAdress { get; set; }

        public string passportId { get; set; }

        public Account account { get; set; }

        public Administrator administrator { get; set; }

    }
}
