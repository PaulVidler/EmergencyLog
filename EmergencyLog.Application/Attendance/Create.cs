using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;

namespace EmergencyLog.Application.Attendance
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Domain.Entities.Attendance Attendance { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Attendance).SetValidator(new AttendanceValidator());
            }
        }


        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private DataContext _context;
            private IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var attendance = await _context.Attendances.FindAsync(request.Attendance.Id);

                if (attendance == null) return null;
                 _mapper.Map(request.Attendance, attendance);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create attendance");

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
