using System;

namespace EmergencyLog.Domain.Entities.Interfaces;

public interface IAttendance
{
    Guid Id { get; set; }
    DateTime TimeIn { get; set; }
    DateTime? TimeOut { get; set; }
    bool OnSite { get; set; }
    bool EntryComplete { get; set; }
    Client Client { get; set; }
}