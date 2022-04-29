using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace EmergencyLog.Application.Validators
{
    internal class AttendanceValidator : AbstractValidator<Domain.Entities.Attendance>
    {
        public AttendanceValidator()
        {
            RuleFor(x => x.TimeIn).NotEmpty();
            RuleFor(x => x.TimeOut).GreaterThan(d => d.TimeIn);
            RuleFor(x => x.OnSite).NotEmpty();
            RuleFor(x => x.EntryComplete).NotEmpty();
            RuleFor(x => x.ClientId).NotEmpty();

        }
    }
}
