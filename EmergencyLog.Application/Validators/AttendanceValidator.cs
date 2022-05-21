using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyLog.Application.Attendance;
using EmergencyLog.Application.DTOs.AttendanceDtos;
using FluentValidation;

namespace EmergencyLog.Application.Validators
{
    internal class AttendanceValidator : AbstractValidator<AttendanceAddDto>
    {
        public AttendanceValidator()
        {
            RuleFor(x => x.TimeIn).NotEmpty();
            RuleFor(x => x.OnSite).NotEmpty();
            RuleFor(x => x.EntryComplete).NotEmpty();
        }
    }
}
