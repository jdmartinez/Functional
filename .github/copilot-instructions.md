# Functional - GitHub Copilot Instructions

This document provides guidance for GitHub Copilot when generating code for the Functional project. Follow these guidelines to ensure that generated code aligns with the project's coding standards and architectural principles.

If you are not sure, do not guess, just tell that you don't know or ask clarifying questions. Don't copy code that follows the same pattern in a different context. Don't rely just on names, evaluate the code based on the implementation and usage. Verify that the generated code is correct and compilable.

## Code Style

### General Guidelines

- Make only high confidence suggestions when reviewing code changes.
- Always use the latest version of C# supported by the project
- Use UK English spelling and grammar.
- Never change NuGet.config files unless explicitly asked to.
- Follow the [.NET coding guidelines](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md) unless explicitly overridden below
- Follow SOLID and clean code principles when possible.
- Apply Domain Driven Design (DDD) principles where applicable.
- Write code that is clean, maintainable, and easy to understand.
- Favor readability over brevity, but keep methods focused and concise.
- Only add comments rarely to explain why a non-intuitive solution was used. The code should be self-explanatory otherwise.
- Don't add the UTF-8 BOM to files unless they have non-ASCII characters.
- Avoid breaking public APIs. If you need to break a public API, add a new API instead and mark the old one as obsolete. Use `ObsoleteAttribute` with the message pointing to the new API.
- For libraries or external dependencies, mention their usage and purpose in comments.
- Write code that is secure by default. Avoid exposing potentially private or sensitive data.

### Formatting

- Apply code-formatting style defined in `.editorconfig` if exists.
- Use spaces for indentation (4 spaces).
- Use braces for all blocks including single-line blocks.
- Place braces on new lines.
- Limit line length to 140 characters.
- Trim trailing whitespace.
- All declarations must begin on a new line.
- Insert a newline before the opening curly brace of any code block (e.g., after `if`, `for`, `while`, `foreach`, `using`, `try`, etc.).
- Use a single blank line to separate logical sections of code when appropriate.
- Ensure that the final return statement of a method is on its own line.
- Insert a final newline at the end of files.
- When using Linq, prefer method syntax over query syntax.
- When using Linq method syntax, place each method call on a new line if there are multiple chained calls.
- Remove unnecessary using directives when saving the file.
- Use pattern matching and switch expressions wherever possible.
- Use `nameof` instead of string literals when referring to member names.

### C# Specific Guidelines

- Use the latest C# language features.
- Prefer file-scoped namespace declarations and single-line using directives.
- Use `var` for local variables.
- Use expression-bodied members where appropriate.
- When using expression-bodied members, it should start in a new line and be indented as needed.
- Prefer using collection expressions when possible.
- Use `is` pattern matching instead of `as` and null checks.
- Prefer `switch` expressions over `switch` statements when appropriate.
- Prefer field-backed property declarations using field contextual keyword instead of an explicit field.
- Prefer range and index from end operators for indexer access.
- The projects use implicit namespaces, so do not add `using` directives for namespaces that are already imported by the project.
- When verifying that a file doesn't produce compiler errors rebuild the whole project.
- Don't use or propose primary constructors in classes.
- Use `record` for immutable types and `class` for mutable types.
- Remove all unnecessary `using` directives, especially those that are not used in the file.

### Naming Conventions

- Use PascalCase for:
  - Classes, structs, enums, properties, methods, events, namespaces, delegates.
  - Public fields.
  - Static private fields.
  - Constants.
- Use camelCase for:
  - Parameters.
  - Local variables.
- Use `_camelCase` for instance private fields.
- Prefix interfaces with `I`.
- Prefix type parameters with `T`.
- Use meaningful and descriptive names.

### Nullability

- Declare variables non-nullable, and check for `null` at entry points.
- Always use `is null` or `is not null` instead of `== null` or `!= null`.
- Trust the C# null annotations and don't add null checks when the type system says a value cannot be null.
- Use proper null-checking patterns.
- Use the null-conditional operator (`?.`) and null-coalescing operator (`??`) when appropriate.

## Architecture and Design Patterns

- This project follows vertical slice architecture.
- Separate concerns by features or modules.
- All endpoints **MUST** be created as Minimal API endpoint and **MUST** be located under `/Features` folder.
- Each feature or module **MUST** have its own folder structure and **MUST** be located under `/Features`.
- Use MediatR for handling commands and queries.
- Use CQRS pattern where appropriate.
- Use Dependency Injection (DI) for managing dependencies.
- Use Repository pattern for data access.
- Use FluentValidation for input validation.
- Prefer mapping objects using extension methods or manual mapping instead of AutoMapper.
- Use `ILogger<T>` for logging.

### Domain Driven Design (DDD)

- **Ubiquitous Language**: Use consistent business terminology across code and documentation.
- **Bounded Contexts**: Clear service boundaries with well-defined responsibilities.
- **Domain Services**: Encapsulate domain logic that doesn't naturally fit within entities or value objects.
- **Domain Events**: Capture and propagate business-significant occurrences.
- **Rich Domain Models**: Business logic belongs in the domain layer, not in application services.

### Domain Layer

- **Value Objects**: Immutable objects representing domain concepts.
- **Domain Services**: Stateless services for complex business operations involving multiple entities.
- **Domain Events**: Capture business-significant state changes.
- **Specifications**: Encapsulate complex business rules and queries.
- **Repositories**: Abstract data access, providing an interface for domain entities.

### Application Layer

- **Use Cases**: Each use case is represented by a dedicated service or handler.
- **DTOs**: Data Transfer Objects for communication between layers.
- **Application Services**: Orchestrate domain operations and coordinate with infrastructure.
- **Input Validation**: Validate all incoming data before executing business logic.
- **Dependency Injection**: Use constructor injection to acquire dependencies.

### Infrastructure Layer

- **Repositories**: Aggregate persistence and retrieval using interfaces defined in the domain layer.
- **Data Mappers / ORMs**: Map domain objects to database schemas.
- **External Service Adapters**: Integrate with external systems.

### Testing

- We use NUnit for tests.
- We use FluentAssertions for assertions.
- Do not emit "Act", "Arrange" or "Assert" comments.
- Use Moq for mocking in tests.
- Copy existing style in nearby files for test method names and capitalization.
- Follow the existing test patterns in the corresponding test projects.
- Create both unit tests and functional tests where appropriate.
- Run tests with project rebuilding enabled (don't use `--no-build`) to ensure code changes are picked up.
- NEVER accept failing tests as "okay" or "acceptable" - all tests must pass before declaring success.
- If any test fails, investigate and fix the root cause - no exceptions.
- Continue working until 100% test success rate is achieved across all test suites.
- Name the test methods descriptively to indicate their purpose and expected behavior using this format.
```
<MethodName>_Should<ExpectedBehavior>_<Condition>
```

## Documentation

- Include XML documentation for all public APIs.
- All documentation **MUST** be in English (UK).
- Add proper `<remarks>` tags with links to relevant documentation where helpful.
- For keywords like `null`, `true` or `false` use `<see langword="*" />` tags.
- Include code examples in documentation where appropriate.
- Overriding members should inherit the XML documentation from the base type via `/// <inheritdoc />`.

## Error Handling

- Use appropriate exception types.
- Avoid catching exceptions without handling them appropriately (logging, rethrowing, or wrapping in a more specific exception type)

## Asynchronous Programming

- Provide asynchronous versions of methods by default.
- Provide both synchronous and asynchronous versions of methods if it makes sense for the use case.
- Use the `Async` suffix for asynchronous methods if there is a corresponding synchronous version.
- Return `Task` or `ValueTask` from asynchronous methods.
- Use `CancellationToken` parameters to support cancellation.
- Avoid async void methods except for event handlers.
- Call `ConfigureAwait(false)` on awaited calls to avoid deadlocks.

## Performance Considerations

- Be mindful of performance implications, especially for database operations.
- Avoid unnecessary allocations.
- Consider using more efficient code that is expected to be on the hot path, even if it is less readable.

## Behavioural constraints for AI agents

- Prefer minimal diffs: change only files necessary for the task.
- Avoid altering centralized version/metadata files (`Directory.*.props`) unless asked explicitly.
- Keep commit messages aligned with Conventional Commits.

If anything here is unclear or you want more examples extracted from specific files, ask and I'll add short, focused snippets.
