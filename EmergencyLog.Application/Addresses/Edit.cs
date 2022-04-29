﻿using AutoMapper;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain.Entities;
using FluentValidation;

namespace EmergencyLog.Application.Addresses
{
    public class Edit
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
            private IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var address = await _context.Addresses.FindAsync(request.Address.Id);

                if (address == null) return null;
                
                // activity.Title = request.Activity.Title ?? activity.Title; // if this is null, then just set it existing title

                // this line below, replaces the line above as a better means of mapping without having to check each property.
                _mapper.Map(request.Address, address);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update Address");

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
