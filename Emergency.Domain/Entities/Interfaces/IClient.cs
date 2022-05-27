using System;
using System.Collections.Generic;

namespace EmergencyLog.Domain.Entities.Interfaces;

public interface IClient
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string Surname { get; set; }
    DateTime? DateOfBirth { get; set; }
    string Email { get; set; }
    string? ImageSmall { get; set; }
    string? ImageLarge { get; set; }
    string? Phone { get; set; }
    string Mobile { get; set; }
    EmergencyContact? EmergencyContact { get; set; }
    ICollection<Attendance>? Attendances { get; set; }
    Organisation Organisation { get; set; }
}