namespace Functional.AspNetCore.Extensions;

using System;
using System.Threading.Tasks;
using Functional.AspNetCore.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public static class EndpointRouteBuilderExtensions
{
    /// <summary>
    /// Mapea un endpoint GET que devuelve un <c>Functional.Result&lt;T&gt;</c> y lo convierte en un <see cref="IResult"/>.
    /// </summary>
    public static IEndpointConventionBuilder MapGetResult<T>(this IEndpointRouteBuilder endpoints, string pattern, Func<HttpContext, Task<Functional.Result<T>>> handler)
    {
        if (endpoints is null) throw new ArgumentNullException(nameof(endpoints));
        if (handler is null) throw new ArgumentNullException(nameof(handler));

        return endpoints.MapGet(pattern, async ctx =>
        {
            var result = await handler(ctx).ConfigureAwait(false);
            await result.ToEndpointResult().ExecuteAsync(ctx).ConfigureAwait(false);
        });
    }

    /// <summary>
    /// Mapea un endpoint GET que devuelve un <c>Functional.Result&lt;T&gt;</c> sin recibir HttpContext.
    /// </summary>
    public static IEndpointConventionBuilder MapGetResult<T>(this IEndpointRouteBuilder endpoints, string pattern, Func<Task<Functional.Result<T>>> handler)
        => endpoints.MapGetResult(pattern, _ => handler());

    /// <summary>
    /// Mapea un endpoint GET que devuelve un <c>Functional.Result</c> (no genérico) y lo convierte en <see cref="IResult"/>.
    /// </summary>
    public static IEndpointConventionBuilder MapGetResult(this IEndpointRouteBuilder endpoints, string pattern, Func<HttpContext, Task<Functional.Result>> handler)
    {
        if (endpoints is null) throw new ArgumentNullException(nameof(endpoints));
        if (handler is null) throw new ArgumentNullException(nameof(handler));

        return endpoints.MapGet(pattern, async ctx =>
        {
            var result = await handler(ctx).ConfigureAwait(false);
            await result.ToEndpointResult().ExecuteAsync(ctx).ConfigureAwait(false);
        });
    }

    /// <summary>
    /// Mapea un endpoint GET que devuelve un <c>Functional.Result</c> sin recibir HttpContext.
    /// </summary>
    public static IEndpointConventionBuilder MapGetResult(this IEndpointRouteBuilder endpoints, string pattern, Func<Task<Functional.Result>> handler)
        => endpoints.MapGetResult(pattern, _ => handler());

    /// <summary>
    /// Mapea un endpoint POST que devuelve un <c>Functional.Result&lt;T&gt;</c> y lo convierte en <see cref="IResult"/>.
    /// </summary>
    public static IEndpointConventionBuilder MapPostResult<T>(this IEndpointRouteBuilder endpoints, string pattern, Func<HttpContext, Task<Functional.Result<T>>> handler)
    {
        if (endpoints is null) throw new ArgumentNullException(nameof(endpoints));
        if (handler is null) throw new ArgumentNullException(nameof(handler));

        return endpoints.MapPost(pattern, async ctx =>
        {
            var result = await handler(ctx).ConfigureAwait(false);
            await result.ToEndpointResult().ExecuteAsync(ctx).ConfigureAwait(false);
        });
    }

    /// <summary>
    /// Mapea un endpoint POST que devuelve un <c>Functional.Result&lt;T&gt;</c> sin recibir HttpContext.
    /// </summary>
    public static IEndpointConventionBuilder MapPostResult<T>(this IEndpointRouteBuilder endpoints, string pattern, Func<Task<Functional.Result<T>>> handler)
        => endpoints.MapPostResult(pattern, _ => handler());

    /// <summary>
    /// Mapea un endpoint POST que devuelve un <c>Functional.Result</c> (no genérico) y lo convierte en <see cref="IResult"/>.
    /// </summary>
    public static IEndpointConventionBuilder MapPostResult(this IEndpointRouteBuilder endpoints, string pattern, Func<HttpContext, Task<Functional.Result>> handler)
    {
        if (endpoints is null) throw new ArgumentNullException(nameof(endpoints));
        if (handler is null) throw new ArgumentNullException(nameof(handler));

        return endpoints.MapPost(pattern, async ctx =>
        {
            var result = await handler(ctx).ConfigureAwait(false);
            await result.ToEndpointResult().ExecuteAsync(ctx).ConfigureAwait(false);
        });
    }

    /// <summary>
    /// Mapea un endpoint POST que devuelve un <c>Functional.Result</c> sin recibir HttpContext.
    /// </summary>
    public static IEndpointConventionBuilder MapPostResult(this IEndpointRouteBuilder endpoints, string pattern, Func<Task<Functional.Result>> handler)
        => endpoints.MapPostResult(pattern, _ => handler());
}
