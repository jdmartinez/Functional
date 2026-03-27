# Functional.AspNetCore

Extensiones para Minimal APIs de ASP.NET Core que facilitan el uso de los tipos del paquete `Functional` (Result, Option, Unit, Validator, Error).

Características principales:

- Extensiones `MapGetResult` y `MapPostResult` para mapear handlers que devuelven `Functional.Result` o `Functional.Result<T>`.
- Conversión automática de `Result`/`Result<T>` a `IResult` para Minimal APIs.
- Soporte para `ProblemDetails` en errores y middleware opcional de manejo de errores.

Uso rápido (Minimal API):

```csharp
using Functional;
using Functional.AspNetCore.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFunctionalMinimalApis();
var app = builder.Build();

// Middleware opcional que convierte excepciones en ProblemDetails
app.UseFunctionalErrorHandling();

// Endpoint que devuelve Result<int> exitoso
app.MapGetResult<int>("/value", () => Task.FromResult(Result.Success(123)));

// Endpoint que devuelve Result genérico fallido
app.MapGetResult("/fail", () => Task.FromResult(Result.Failure(new Error("ERR", "Invalid request"))));

// POST que devuelve Result<T>
app.MapPostResult<string>('/create', async ctx =>
{
	// lógica que produce Result<string>
	return Result.Success("created-id");
});

app.Run();
```

Comportamiento de errores:

- Cuando un `Result<T>` es failure, la respuesta será `application/problem+json` con un `ProblemDetails` que contiene `title` y `detail` basados en `Error`.
- Para `Result` (no genérico) en failure, se devuelve también `ProblemDetails` con status 400.

Notas de empaquetado:

- `PackageId` es `Functional.AspNetCore`.
- Las versiones de paquetes se gestionan centralmente en `Directory.Packages.props` y la versión del paquete la gestiona `GitVersion` (consistente con el repositorio principal).
