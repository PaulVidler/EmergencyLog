using EmergencyLog.Application.Core;
using MediatR;

namespace EmergencyLog.Application
{
    public class ListQuery<T> : IRequest<Result<PagedList<T>>>
    {
        public PagingParams Params { get; set; }
    }

}
