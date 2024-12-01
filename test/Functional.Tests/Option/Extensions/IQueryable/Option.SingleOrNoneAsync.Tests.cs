using FluentAssertions;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public async Task SingleOrNoneAsync_ShouldReturnNone_IfEntitiesFound()
    {
        var context = new TestContext();

        var result = await context.People.SingleOrNoneAsync();
        
        result.IsSome.Should().BeFalse();
    }

    [Fact]
    public async Task SingleOrNone_ShouldReturnSome_IfEntitiesFound()
    {
        var context = new TestContext();
        var person = new Person();
        
        await context.People.AddAsync(person);
        await context.SaveChangesAsync();
        
        var result = await context.People.SingleOrNoneAsync();
        
        result.IsSome.Should().BeTrue();
        result.Value.Id.Should().Be(person.Id);
    }

    [Fact]
    public async Task SingleOrNoneAsync_ShouldReturnNone_IfNoMatchingEntitiesFound()
    {
        var context = new TestContext();
        var persons = Enumerable.Range(0, 10)
            .Select(_ => new Person());
        
        await context.People.AddRangeAsync(persons);
        await context.SaveChangesAsync();
        
        var result = await context.People.SingleOrNoneAsync(p => p.Id > 10);
        
        result.IsSome.Should().BeFalse();
    }

    [Fact]
    public async Task SingleOrNoneAsync_ShouldReturnSome_IfMatchFound()
    {
        var context = new TestContext();
        var persons = Enumerable.Range(0, 10)
            .Select(_ => new Person());
        
        await context.People.AddRangeAsync(persons);
        await context.SaveChangesAsync();
        
        var result = await context.People.SingleOrNoneAsync(p => p.Id == 1);
        
        result.IsSome.Should().BeTrue();
        result.Value.Id.Should().Be(1);
    }
    
}
