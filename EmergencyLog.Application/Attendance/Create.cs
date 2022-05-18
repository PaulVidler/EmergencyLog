using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Interfaces;
using EmergencyLog.Application.Validators;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserAccessor _userAccessor;

        public CreateHandler(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<Domain.Entities.Attendance> request, CancellationToken cancellationToken)
        {
            // this is an example of how to use the GetUserName method to fetch user claims. This can be changed to supply the full object for OrgId etc if required.
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUserName());
            
            _context.Attendances.Add(request.Type);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Attendance");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
