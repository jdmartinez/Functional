using FluentAssertions;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void SingleOrNone_ShouldReturnSuccess_WhenFirstItemFound()
    {
        var query = Enumerable.Range(0, 1)
            .Select(v => new TestClass { Id = v.ToString() })
            .AsQueryable();

        var expected = query.SingleOrDefault();

        var option = query.SingleOrNone();

        option.IsSome.Should().BeTrue();
        option.Value.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void SingleOrNone_ShouldReturnSuccess_WhenFirstItemFoundUsingPredicate()
    {
        var query = Enumerable.Range(0, 1)
            .Select(v => new TestClass { Id = v.ToString() })
            .AsQueryable();
        var expected = query.SingleOrDefault(item => item.Id == "0");

        var option = query.SingleOrNone(item => item.Id == "0");

        option.IsSome.Should().BeTrue();
        option.Value.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void SingleOrNone_ShouldReturnSuccess_WhenQueryIsEmpty()
    {
        var query = new List<TestClass>().AsQueryable();
        var expected = query.SingleOrDefault();

        var option = query.SingleOrNone();

        option.IsSome.Should().BeFalse();
    }

    [Fact]
    public void SingleOrNone_ShouldReturnSuccess_WhenNoItemFoundUsingPredicate()
    {
        var query = Enumerable.Range(0, 100)
            .Select(v => new TestClass { Id = v.ToString() })
            .AsQueryable();
        var expected = query.SingleOrDefault(item => item.Id == "100");

        var option = query.SingleOrNone(item => item.Id == "100");

        option.IsSome.Should().BeFalse();
    }
}
