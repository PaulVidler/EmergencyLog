﻿using System;

namespace EmergencyLog.Application.DTOs.AttendanceDtos
{
    public class AttendanceEditDto
    {
        public int Id { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool OnSite { get; set; }
        public bool EntryComplete { get; set; }
    }
}
