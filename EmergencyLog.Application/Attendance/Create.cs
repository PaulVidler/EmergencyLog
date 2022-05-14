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
    public class CreateCommandValidator : AbstractValidator<CreateCommand<Domain.Entities.Attendance>>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new AttendanceValidator());
        }
    }


    public class CreateHandler : IRequestHandler<CreateCommand<Domain.Entities.Attendance>, Result<Unit>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public CreateHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<Domain.Entities.Attendance> request, CancellationToken cancellationToken)
        {
            _context.Attendances.Add(request.Type);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Attendance");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
