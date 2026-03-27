namespace Functional.AspNetCore;

using Microsoft.AspNetCore.Builder;

public static class WebApplicationUseExtensions
{
    /// <summary>
    /// Agrega el middleware de manejo de errores de Functional.
    /// </summary>
    public static WebApplication UseFunctionalErrorHandling(this WebApplication app)
    {
        app.UseMiddleware<FunctionalErrorHandlingMiddleware>();
        return app;
    }
}
