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
    /// Maps a PUT endpoint that returns a <see cref="Result{T}"/>.
    /// </summary>
    public static IEndpointConventionBuilder MapPutResult<T>(this IEndpointRouteBuilder endpoints, string pattern, Func<HttpContext, Task<Result<T>>> handler)
    {
        ArgumentNullException.ThrowIfNull(endpoints);
        ArgumentNullException.ThrowIfNull(handler);

        return endpoints.MapPut(pattern, ExecuteEndpoint(handler));
    }

    /// <summary>
    /// Maps a PUT endpoint that returns a <see cref="Result{T}"/>.
    /// </summary>
    public static IEndpointConventionBuilder MapPutResult<T>(this IEndpointRouteBuilder endpoints, string pattern, Func<Task<Result<T>>> handler)
        => endpoints.MapPutResult(pattern, _ => handler());

    /// <summary>
    /// Maps a PUT endpoint that returns a <see cref="Result"/>.
    /// </summary>
    public static IEndpointConventionBuilder MapPutResult(this IEndpointRouteBuilder endpoints, string pattern, Func<HttpContext, Task<Result>> handler)
    {
        ArgumentNullException.ThrowIfNull(endpoints);
        ArgumentNullException.ThrowIfNull(handler);

        return endpoints.MapPut(pattern, ExecuteEndpoint(handler));
    }

    /// <summary>
    /// Maps a PUT endpoint that returns a <see cref="Result"/>.
    /// </summary>
    public static IEndpointConventionBuilder MapPutResult(this IEndpointRouteBuilder endpoints, string pattern, Func<Task<Result>> handler)
        => endpoints.MapPutResult(pattern, _ => handler());
}
