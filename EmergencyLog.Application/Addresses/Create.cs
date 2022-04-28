using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;

namespace EmergencyLog.Application.Addresses
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Address Address { get; set; }
        }

        
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Address).SetValidator(new AddressValidator());
            }
        }


        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Addresses.Add(request.Address);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to create Address");

                // This value is essentially a void or null value, which allows the API to know
                // we are finished whatever we are doing in here. This is why we need the return type of 'Task<Unit>' in the signature
                // A unit is a MediatR struct that represents a void or null value.
                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
