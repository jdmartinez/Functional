using Shouldly;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public async Task SingleOrNoneAsync_ShouldReturnNone_IfEntitiesFound()
    {
        var context = new TestContext();

        var result = await context.People.SingleOrNoneAsync();

        result.IsSome.ShouldBeFalse();
    }

    [Fact]
    public async Task SingleOrNone_ShouldReturnSome_IfEntitiesFound()
    {
        var context = new TestContext();
        var person = new Person();

        await context.People.AddAsync(person);
        await context.SaveChangesAsync();

        var result = await context.People.SingleOrNoneAsync();

        result.IsSome.ShouldBeTrue();
        result.Value.Id.ShouldBe(person.Id);
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

        result.IsSome.ShouldBeFalse();
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

        result.IsSome.ShouldBeTrue();
        result.Value.Id.ShouldBe(1);
    }

}
