using System;

namespace Functional;

public interface IValidationRule<T>
{
    bool Validate(T value);

    Error Error { get; }
}
