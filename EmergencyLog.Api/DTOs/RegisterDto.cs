﻿using System;

namespace EmergencyLog.Api.DTOs
{
    public class RegisterDto
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public  string Password { get; set; }
        public string UserName { get; set; }
        public Guid OrganisationId { get; set; }
    }
}
