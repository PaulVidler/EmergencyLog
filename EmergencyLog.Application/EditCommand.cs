using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using MediatR;

namespace EmergencyLog.Application
{
    public class EditCommand<T> : IRequest<Result<Unit>>
    {
        public T GenericType { get; set; }
    }
}
