namespace Functional.AspNetCore.Extensions;

using Microsoft.AspNetCore.Builder;

public static class WebApplicationUseExtensions
{
    /// <summary>
    /// Agrega el middleware de manejo de errores de Functional.
    /// </summary>
    public static WebApplication UseFunctionalErrorHandling(this WebApplication app)
    {
        app.UseMiddleware<Functional.AspNetCore.Middleware.FunctionalErrorHandlingMiddleware>();
        return app;
    }
}
