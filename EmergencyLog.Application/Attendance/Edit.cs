using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Attendance
{
    public class EditCommandValidator : AbstractValidator<EditCommand<Domain.Entities.Attendance>>
    {
        //public EditCommandValidator()
        //{
        //    RuleFor(x => x.Type).SetValidator(new AttendanceValidator());
        //}
    }

    public class Handler : IRequestHandler<EditCommand<Domain.Entities.Attendance>, Result<Unit>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(EditCommand<Domain.Entities.Attendance> request, CancellationToken cancellationToken)
        {

            var attendance = await _context.Attendances.FindAsync(request.Type.Id);

            if (attendance == null) return null;

            // _mapper.Map(request.Type, attendance);

            // when it gets to here, it loses a lot of properties from the original entry,
            // need to work out how to only change the properties that are required, not null out everything else

            _mapper.Map(attendance, request.Type);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to update Attendance");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
