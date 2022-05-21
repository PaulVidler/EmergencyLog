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
using EmergencyLog.Application.DTOs.AttendanceDtos;

namespace EmergencyLog.Application.Attendance
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand<AttendanceAddDto>>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new AttendanceValidator());
        }
    }


    public class CreateHandler : IRequestHandler<CreateCommand<AttendanceAddDto>, Result<Unit>>
    {
        private DataContext _context;
        private readonly IUserAccessor _userAccessor;
        private IMapper _mapper;

        public CreateHandler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<AttendanceAddDto> request, CancellationToken cancellationToken)
        {
            // this below is example code for getting the current user, using the new interface and GetUser() method
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUser());

            var mappedAttendance = _mapper.Map<AttendanceAddDto, Domain.Entities.Attendance>(request.Type);

            _context.Attendances.Add(mappedAttendance);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Attendance");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
