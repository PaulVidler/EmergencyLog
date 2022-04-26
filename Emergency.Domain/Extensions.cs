using EmergencyLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EmergencyLog.Domain
{
    public static class Extensions
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> queryable, ref int pageNumber, ref int pageSize,
            string? sortBy = null, int defaultPageSize = 20)
        {
            if (queryable == null) throw new ArgumentNullException(nameof(queryable));

            if (pageNumber <= 0)
                pageNumber = 1;

            if (pageSize <= 0)
                pageSize = defaultPageSize;

            if (!string.IsNullOrWhiteSpace(sortBy))
                queryable = queryable.OrderBy(sortBy);

            var page = queryable
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return page;
        }


        public static async Task<PagedList<T>> ToPagedList<T>(this IQueryable<T> queryable, int pageNumber,
            int pageSize, long totalCount)
        {
            if (queryable == null) throw new ArgumentNullException(nameof(queryable));

            var list = await queryable.ToListAsync();

            return new PagedList<T>(list, pageNumber, pageSize, totalCount);
        }
    }
}
