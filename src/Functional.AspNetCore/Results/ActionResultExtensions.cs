namespace Functional.AspNetCore.Results;

using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public static class ActionResultExtensions
{
    public static IResult ToEndpointResult(this Functional.Result result)
    {
        return new FunctionalResultHttpResult(result);
    }

    public static IResult ToEndpointResult<T>(this Functional.Result<T> result)
    {
        return new FunctionalResultOfTHttpResult<T>(result);
    }

    private sealed class FunctionalResultHttpResult : IResult
    {
        private readonly Functional.Result _result;

        public FunctionalResultHttpResult(Functional.Result result) => _result = result;

        public async Task ExecuteAsync(HttpContext httpContext)
        {
            if (_result.IsSuccess)
            {
                httpContext.Response.StatusCode = StatusCodes.Status200OK;
                // No content by default for non-generic Result
                return;
            }

            var problem = new ProblemDetails
            {
                Title = "Request failed",
                Detail = string.Empty,
                Status = StatusCodes.Status400BadRequest
            };

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            httpContext.Response.ContentType = "application/problem+json";
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problem)).ConfigureAwait(false);
        }
    }

    private sealed class FunctionalResultOfTHttpResult<T> : IResult
    {
        private readonly Functional.Result<T> _result;

        public FunctionalResultOfTHttpResult(Functional.Result<T> result) => _result = result;

        public async Task ExecuteAsync(HttpContext httpContext)
        {
            if (_result.IsSuccess)
            {
                httpContext.Response.StatusCode = StatusCodes.Status200OK;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsJsonAsync(_result.Value).ConfigureAwait(false);
                return;
            }

            var pd = new ProblemDetails
            {
                Title = _result.Error.Code ?? "Error",
                Detail = _result.Error.Message,
                Status = StatusCodes.Status400BadRequest
            };

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            httpContext.Response.ContentType = "application/problem+json";
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(pd)).ConfigureAwait(false);
        }
    }
}
