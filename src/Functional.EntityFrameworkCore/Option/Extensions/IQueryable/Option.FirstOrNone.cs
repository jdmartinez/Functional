using System.Linq.Expressions;

namespace Functional;

public static partial class OptionExtensions
{
    public static Option<T> FirstOrNone<T>(this IQueryable<T> query)
        => query.FirstOrDefault();

    public static Option<T> FirstOrNone<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate)
        => query.FirstOrDefault(predicate);
}
