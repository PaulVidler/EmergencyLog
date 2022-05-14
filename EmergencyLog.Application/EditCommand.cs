using EmergencyLog.Application.Core;
using MediatR;

namespace EmergencyLog.Application
{
    public class EditCommand<T> : IRequest<Result<Unit>>
    {
        public T Type { get; set; }
    }
}
