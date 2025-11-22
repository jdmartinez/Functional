using System.Threading.Tasks;
using Xunit;

namespace Functional.AspNetCore.Tests;

public class MinimalApiExtensionsTests
{
    [Fact]
    public Task AddFunctionalMinimalApis_ShouldReturnServiceCollection_WhenCalled()
    {
        // This test ensures the extension method exists and is callable.
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        var returned = Functional.AspNetCore.Extensions.WebApplicationExtensions.AddFunctionalMinimalApis(services);
        Assert.NotNull(returned);
        Assert.Same(services, returned);
        return Task.CompletedTask;
    }
}
