using System;

namespace EmergencyLog.Api.DTOs
{
    public class UserDto
    {
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public Guid OrganisationId { get; set; }

    }
}
