using System;

namespace EmergencyLog.Api.DTOs.IdentityDtos
{
    public class UserDto
    {
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public int OrganisationId { get; set; }

    }
}
