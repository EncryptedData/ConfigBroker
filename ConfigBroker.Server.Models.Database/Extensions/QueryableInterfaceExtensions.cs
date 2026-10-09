using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database.Extensions;

public static class QueryableInterfaceExtensions
{
    public static IQueryable<T> SetTracking<T>(this IQueryable<T> queryable, bool isTracking)
        where T : class
    {
        if (isTracking is false)
        {
            queryable = queryable.AsNoTracking();
        }

        return queryable;
    }
}