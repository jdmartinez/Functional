
# Minimal API sample

Ejemplo mínimo mostrando `MapGetResult` y `UseFunctionalErrorHandling`:

```csharp
using Functional;
using Functional.AspNetCore.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFunctionalMinimalApis();
var app = builder.Build();

app.UseFunctionalErrorHandling();

app.MapGetResult<int>("/ok", () => Task.FromResult(Result.Success(10)));
app.MapGetResult("/fail", () => Task.FromResult(Result.Failure(new Error("E001", "Bad input"))));

app.Run();
```

En este ejemplo: éxito → `200` con JSON (para genéricos), fallo → `400` con `application/problem+json`.
