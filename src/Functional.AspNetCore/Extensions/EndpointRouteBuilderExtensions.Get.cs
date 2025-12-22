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
    /// <summary>
    /// Maps an endpoint GET that returns a <c>Functional.Result{T}</c> and converts it to an <see cref="IResult"/>.
    /// </summary>
    public static IEndpointConventionBuilder MapGetResult<T>(this IEndpointRouteBuilder endpoints, string pattern, Func<HttpContext, Task<Result<T>>> handler)
    {
        ArgumentNullException.ThrowIfNull(endpoints);
        ArgumentNullException.ThrowIfNull(handler);

        return endpoints.MapGet(pattern, ExecuteEndpoint(handler));
    }

    /// <summary>
    /// Maps an endpoint GET that returns a <c>Functional.Result{T}</c> without receiving HttpContext.
    /// </summary>
    public static IEndpointConventionBuilder MapGetResult<T>(this IEndpointRouteBuilder endpoints, string pattern, Func<Task<Result<T>>> handler)
        => endpoints.MapGetResult(pattern, _ => handler());

    /// <summary>
    /// Maps an endpoint GET that returns a <c>Functional.Result</c> (non-generic) and converts it to an <see cref="IResult"/>.
    /// </summary>
    public static IEndpointConventionBuilder MapGetResult(this IEndpointRouteBuilder endpoints, string pattern, Func<HttpContext, Task<Result>> handler)
    {
        ArgumentNullException.ThrowIfNull(endpoints);
        ArgumentNullException.ThrowIfNull(handler);

        return endpoints.MapGet(pattern, ExecuteEndpoint(handler));
    }

    /// <summary>
    /// Maps an endpoint GET that returns a <c>Functional.Result</c> without receiving HttpContext.
    /// </summary>
    public static IEndpointConventionBuilder MapGetResult(this IEndpointRouteBuilder endpoints, string pattern, Func<Task<Result>> handler)
        => endpoints.MapGetResult(pattern, _ => handler());
}
