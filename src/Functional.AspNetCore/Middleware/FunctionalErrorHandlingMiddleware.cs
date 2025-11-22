namespace Functional.AspNetCore.Middleware;

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public sealed class FunctionalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<FunctionalErrorHandlingMiddleware> _logger;

    public FunctionalErrorHandlingMiddleware(RequestDelegate next, ILogger<FunctionalErrorHandlingMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception in FunctionalErrorHandlingMiddleware");

            var pd = new ProblemDetails
            {
                Title = "Unhandled exception",
                Detail = ex.Message,
                Status = StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(pd)).ConfigureAwait(false);
        }
    }
}
