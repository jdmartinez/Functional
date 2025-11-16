using Shouldly;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public async Task FirstOrNoneAsync_ShouldReturnNone_IfEntitiesFound()
    {
        var context = new TestContext();

        var result = await context.People.FirstOrNoneAsync();

        result.IsSome.ShouldBeFalse();
    }

    [Fact]
    public async Task FirstOrNone_ShouldReturnSome_IfEntitiesFound()
    {
        var context = new TestContext();
        var person = new Person();

        await context.People.AddAsync(person);
        await context.SaveChangesAsync();

        var result = await context.People.FirstOrNoneAsync();

        result.IsSome.ShouldBeTrue();
        result.Value.Id.ShouldBe(person.Id);
    }

    [Fact]
    public async Task FirstOrNoneAsync_ShouldReturnNone_IfNoMatchingEntitiesFound()
    {
        var context = new TestContext();
        var persons = Enumerable.Range(0, 10)
            .Select(i => new Person());

        await context.People.AddRangeAsync(persons);
        await context.SaveChangesAsync();

        var result = await context.People.FirstOrNoneAsync(p => p.Id > 10);

        result.IsSome.ShouldBeFalse();
    }

    [Fact]
    public async Task FirstOrNoneAsync_ShouldReturnSome_IfMatchFound()
    {
        var context = new TestContext();
        var persons = Enumerable.Range(0, 10)
            .Select(_ => new Person());

        await context.People.AddRangeAsync(persons);
        await context.SaveChangesAsync();

        var result = await context.People.FirstOrNoneAsync(p => p.Id == 1);

        result.IsSome.ShouldBeTrue();
        result.Value.Id.ShouldBe(1);
    }

}
