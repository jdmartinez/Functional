using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Functional;

public static partial class OptionExtensions
{
    public static async Task<Option<T>> SingleOrNoneAsync<T>(this IQueryable<T> source, CancellationToken cancellationToken = default)
        => await source.SingleOrDefaultAsync(cancellationToken);

    public static async Task<Option<T>> SingleOrNoneAsync<T>(
        this IQueryable<T> source,
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
        => await source.FirstOrDefaultAsync(predicate, cancellationToken);

}
