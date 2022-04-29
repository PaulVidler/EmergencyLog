﻿using AutoMapper;
using EmergencyLog.Domain;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain.Entities;
using FluentValidation;

namespace EmergencyLog.Application.EmergencyContacts
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public EmergencyContact EmergencyContact { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.EmergencyContact).SetValidator(new EmergencyContactValidator());
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

                var emergencyContact = await _context.EmergencyContacts.FindAsync(request.EmergencyContact.Id);

                if (emergencyContact == null) return null;

                _mapper.Map(request.EmergencyContact, emergencyContact);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update emergencyContact");

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
