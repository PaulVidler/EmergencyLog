using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;

namespace EmergencyLog.Application.Clients
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Client Client { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Client).SetValidator(new ClientsValidator());
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
                _context.Clients.Add(request.Client);
                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create Client");

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
