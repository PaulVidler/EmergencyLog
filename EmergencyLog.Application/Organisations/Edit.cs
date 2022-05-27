using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.DTOs.OrganisationDtos;

namespace EmergencyLog.Application.Organisations
{
    public class EditCommandValidator : AbstractValidator<EditCommand<Organisation>>
    {
        public EditCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new OrganisationValidator());
        }
    }

    public class EditHandler : IRequestHandler<EditCommand<OrganisationEditDto>, Result<Unit>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public EditHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(EditCommand<OrganisationEditDto> request, CancellationToken cancellationToken)
        {

            var organisation = await _context.Organisations.FindAsync(request.Type.Id);

            if (organisation == null) return null;

            _mapper.Map(request.Type, organisation);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to update Organisation");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
