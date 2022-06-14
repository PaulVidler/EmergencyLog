using System;
using EmergencyLog.Application.DTOs.ClientDtos;
using EmergencyLog.Domain.Entities;

namespace EmergencyLog.Application.DTOs.AttendanceDtos
{
    public class AttendanceResultDto
    {
        public int Id { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool OnSite { get; set; }
        public bool EntryComplete { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
