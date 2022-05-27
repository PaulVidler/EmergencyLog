using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.DTOs.PropertyDtos;

namespace EmergencyLog.Application.Property
{
    public class EditCommandValidator : AbstractValidator<EditCommand<Domain.Entities.Property>>
    {
        public EditCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new PropertyValidator());
        }
    }

    public class EditHandler : IRequestHandler<EditCommand<PropertyEditDto>, Result<Unit>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public EditHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(EditCommand<PropertyEditDto> request, CancellationToken cancellationToken)
        {

            var property = await _context.Properties.FindAsync(request.Type.Id);

            if (property == null) return null;

            _mapper.Map(request.Type, property);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to update Property");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
