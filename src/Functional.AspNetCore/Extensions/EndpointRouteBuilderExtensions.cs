namespace Functional.AspNetCore;

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

/// <summary>
/// Extension methods for <see cref="IEndpointRouteBuilder"/> to map Functional endpoints.
/// </summary>
public static partial class EndpointRouteBuilderExtensions
{
    private static RequestDelegate ExecuteEndpoint<T>(Func<HttpContext, Task<Result<T>>> handler)
        => async ctx =>
        {
            var result = await handler(ctx).ConfigureAwait(false);
            await result.ToEndpointResult().ExecuteAsync(ctx).ConfigureAwait(false);
        };

    private static RequestDelegate ExecuteEndpoint(Func<HttpContext, Task<Result>> handler)
        => async ctx =>
        {
            var result = await handler(ctx).ConfigureAwait(false);
            await result.ToEndpointResult().ExecuteAsync(ctx).ConfigureAwait(false);
        };
}
