using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators.FireSafetyHardwareValidators;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.DTOs.FireExtinguisherDtos;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class EditCommandValidator : AbstractValidator<EditCommand<FireExtinguisher>>
    {
        public EditCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new FireExtinguisherValidator());
        }
    }

    public class EditHandler : IRequestHandler<EditCommand<FireExtinguisherEditDto>, Result<Unit>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public EditHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(EditCommand<FireExtinguisherEditDto> request, CancellationToken cancellationToken)
        {

            var fireExtinguisher = await _context.FireExtinguishers.FindAsync(request.Type.Id);

            if (fireExtinguisher == null) return null;

            _mapper.Map(request.Type, fireExtinguisher);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to update FireExtinguisher");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
