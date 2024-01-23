﻿namespace Functional;

public readonly partial record struct Result
{
    public static Result<T> Success<T>(T value) => Result<T>.Success(value);

    public static Result<T> Failure<T>(IEnumerable<Error> errors) => Result<T>.Failure(errors);
}
