# Functional.Types

Functional primitives and extensions for C#.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) ![Build](https://github.com/jdmartinez/Functional/actions/workflows/dotnet.yml/badge.svg) [![Code Quality](https://github.com/jdmartinez/Functional/actions/workflows/code-quality.yml/badge.svg)](https://github.com/jdmartinez/Functional/actions/workflows/code-quality.yml)

`Functional.Types` (NuGet: `Functional.Types`) is a lightweight library of functional primitives and helpers for .NET:

- `Option<T>` — optional values and combinators.
- `Result<T, E>` — explicit success/failure flow.
- `Unit` — a single value type representing absence of data.
- `Error` and `Validator` — small validation helpers.

In addition to the core library, this repository contains a separate package for Entity Framework Core integration: `Functional.Types.EntityFrameworkCore`.

## Contents

- [Functional.Types](#functionaltypes)
  - [Contents](#contents)
  - [Overview](#overview)
  - [Packages](#packages)
  - [Installation](#installation)
  - [Quick examples](#quick-examples)
  - [Migration notes](#migration-notes)
  - [Build \& tests](#build--tests)
  - [Versioning \& releases](#versioning--releases)
  - [Contributing](#contributing)
  - [Licence](#licence)

## Overview

`Functional.Types` aims to provide a small, well-tested set of types and extensions to make functional-style code straightforward in C#, while keeping the core package free of heavier dependencies. Integrations (for example EF Core) are distributed as optional, separate packages to avoid unnecessary transitive dependencies.

Principles:

- Small dependency-free core.
- Composable primitives with clear semantics.
- Opt-in integration packages.

## Packages

- `Functional.Types` — core primitives and helpers.
- `Functional.Types.EntityFrameworkCore` — EF Core `IQueryable` extensions and async/sync helpers (for example `FirstOrNoneAsync`, `SingleOrNoneAsync`), which depends on `Functional.Types`.

Package IDs published to NuGet follow the project names under `/src`.

## Installation

Install the core package using `dotnet`:

```bash
dotnet add package Functional.Types
```

For EF Core integration:

```bash
dotnet add package Functional.Types.EntityFrameworkCore
```

Both packages target .NET 10 (`net10.0`).

## Quick examples

Option handling:

```csharp
using Functional.Types;

Option<int> maybe = Option.Some(3);

int doubled = maybe.Match(
  some: v => v * 2,
  none: () => 0
);
```

Result usage:

```csharp
using Functional.Types;

Result<int, string> r = Result.Ok<int, string>(42);

r.Match(
  ok: v => Console.WriteLine($"Value: {v}"),
  err: e => Console.WriteLine($"Error: {e}")
);
```

EF Core example (async):

```csharp
using Functional.Types.EntityFrameworkCore.Option.Extensions.IQueryable;

var maybeUser = await dbContext.Users.Where(u => u.Id == id).FirstOrNoneAsync();
```

## Migration notes

- EF Core extensions were extracted from the core package. If you previously relied on EF extensions being present in the main package, add a dependency on `Functional.Types.EntityFrameworkCore`.

## Build & tests

Requirements: .NET 10 SDK

From the repository root:

```bash
dotnet build
dotnet test
```

The repository includes GitHub Actions workflows for CI and automated publishing.

## Versioning & releases

This project uses GitVersion (ContinuousDeployment) along with a calendar-tag release process (`YYYY.MM.PATCH`). The `nuget.yml` workflow generates release notes from Conventional Commit messages when an annotated tag is pushed.

To create packages locally:

```bash
dotnet pack src/Functional/Functional.csproj -c Release
dotnet pack src/Functional.EntityFrameworkCore/Functional.EntityFrameworkCore.csproj -c Release
```

To publish to NuGet, set `NUGET_API_KEY` in your CI environment and push an annotated tag to trigger the workflow.

## Contributing

Contributions are welcome. Quick guidelines:

- Use Conventional Commits for commit messages.
- Add tests for new behaviour.
- Keep the core package dependency-free; add integrations as separate projects.

Suggested PR title format: `feat: ...` / `fix: ...` / `chore: ...`. Use `!` to denote breaking changes.

## Licence

This project is licensed under MIT. See the `LICENSE` file for details.
