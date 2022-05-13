using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace EmergencyLog.Application.Addresses
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand<Address>>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.GenericType).SetValidator(new AddressValidator());
        }
    }
    
    public class CreateHandler : IRequestHandler<CreateCommand<Address>, Result<Unit>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public CreateHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<Address> request, CancellationToken cancellationToken)
        {

            var address = await _context.Addresses.FindAsync(request.GenericType.Id);

            if (address == null) return null;
            
            _mapper.Map(request.GenericType, address);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Address");

            return Result<Unit>.Success(Unit.Value);

        }
    }
    
}
