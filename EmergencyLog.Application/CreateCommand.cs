using EmergencyLog.Application.Core;
using MediatR;

namespace EmergencyLog.Application
{
    public class CreateCommand<T> : IRequest<Result<Unit>> where T : class
    {
        public T Type { get; set; }
    }
}
