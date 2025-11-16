using System.Linq.Expressions;

namespace Functional;

public static partial class OptionExtensions
{
    public static Option<T> SingleOrNone<T>(this IQueryable<T> query)
        => query.SingleOrDefault();

    public static Option<T> SingleOrNone<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate)
        => query
            .SingleOrDefault(predicate);
}
