using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Functional.AspNetCore.Tests;

public class ResultToProblemDetailsTests
{
    [Fact]
    public async Task ResultOfT_Success_WritesJson()
    {
        var ctx = new DefaultHttpContext();
        var ms = new MemoryStream();
        ctx.Response.Body = ms;

        var result = Result<int>.Success(42);
        var iresult = ActionResultExtensions.ToEndpointResult(result);
        await iresult.ExecuteAsync(ctx);

        ctx.Response.Body.Seek(0, SeekOrigin.Begin);
        var sr = new StreamReader(ctx.Response.Body, Encoding.UTF8);
        var body = await sr.ReadToEndAsync();

        Assert.Equal(200, ctx.Response.StatusCode);
        // JSON for number 42 is "42"
        Assert.Equal("42", JsonSerializer.Deserialize<int>(body).ToString());
    }

    [Fact]
    public async Task ResultOfT_Failure_WritesProblemDetails()
    {
        var ctx = new DefaultHttpContext();
        var ms = new MemoryStream();
        ctx.Response.Body = ms;

        var err = new Error("ERR_CODE", "Something went wrong");
        var result = Result<int>.Failure(err);
        var iresult = ActionResultExtensions.ToEndpointResult(result);
        await iresult.ExecuteAsync(ctx);

        ctx.Response.Body.Seek(0, SeekOrigin.Begin);
        var sr = new StreamReader(ctx.Response.Body, Encoding.UTF8);
        var body = await sr.ReadToEndAsync();

        Assert.Equal(400, ctx.Response.StatusCode);
        Assert.Equal("application/problem+json", ctx.Response.ContentType);
        Assert.Contains("Something went wrong", body);
        Assert.Contains("ERR_CODE", body);
    }
}
