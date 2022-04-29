using AutoMapper;
using EmergencyLog.Domain;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain.Entities;
using FluentValidation;

namespace EmergencyLog.Application.Property
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Domain.Entities.Property Property { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Property).SetValidator(new PropertyValidator());
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

                var property = await _context.Properties.FindAsync(request.Property.Id);

                if (property == null) return null;

                _mapper.Map(request.Property, property);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update Property");

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
