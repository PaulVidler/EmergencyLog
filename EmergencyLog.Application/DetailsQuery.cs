using EmergencyLog.Application.Core;
using MediatR;
using System;

namespace EmergencyLog.Application
{
    public class DetailsQuery<T> : IRequest<Result<T>>
    {
        public Guid Id { get; set; }
    }
}
