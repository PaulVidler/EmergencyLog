using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using MediatR;

namespace EmergencyLog.Application
{
    public class CreateCommand<T> : IRequest<Result<Unit>> where T : class
    {
        public T GenericType { get; set; }
    }
}
