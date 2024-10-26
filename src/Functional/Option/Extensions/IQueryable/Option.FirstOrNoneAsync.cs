using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Functional;

public static partial class OptionExtensions
{
    public static async Task<Option<T>> FirstOrNoneAsync<T>(this IQueryable<T> source, CancellationToken cancellationToken = default)
        => await source.FirstOrDefaultAsync(cancellationToken);

    public static async Task<Option<T>> FirstOrNoneAsync<T>(
        this IQueryable<T> source,
        Expression<Func<T, bool>> predicate, 
        CancellationToken cancellationToken = default)
        => await source.FirstOrDefaultAsync(predicate, cancellationToken);

}
