using EmergencyLog.Application.Core;
using MediatR;
using System;

namespace EmergencyLog.Application
{
    public class DeleteCommand<T> : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
    }
}
