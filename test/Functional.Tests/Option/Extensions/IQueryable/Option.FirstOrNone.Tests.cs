using FluentAssertions;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void FirstOrNone_ShouldReturnSuccess_WhenFirstItemFound()
    {
        var query = Enumerable.Range(0, 100)
            .Select(v => new TestClass { Id = v.ToString() })
            .AsQueryable();
        var expected = query.FirstOrDefault();

        var option = query.FirstOrNone();

        option.IsSome.Should().BeTrue();
        option.Value.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void FirstOrNone_ShouldReturnSuccess_WhenFirstItemFoundUsingPredicate()
    {
        var query = Enumerable.Range(0, 100)
            .Select(v => new TestClass { Id = v.ToString() })
            .AsQueryable();
        var expected = query.FirstOrDefault(item => item.Id == "1");

        var option = query.FirstOrNone(item => item.Id == "1");

        option.IsSome.Should().BeTrue();
        option.Value.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void FirstOrNone_ShouldReturnSuccess_WhenQueryIsEmpty()
    {
        var query = new List<TestClass>().AsQueryable();
        var expected = query.FirstOrDefault();

        var option = query.FirstOrNone();

        option.IsSome.Should().BeFalse();
    }

    [Fact]
    public void FirstOrNone_ShouldReturnSuccess_WhenNoItemFoundUsingPredicate()
    {
        var query = Enumerable.Range(0, 100)
            .Select(v => new TestClass { Id = v.ToString() })
            .AsQueryable();
        var expected = query.FirstOrDefault(item => item.Id == "100");

        var option = query.FirstOrNone(item => item.Id == "100");

        option.IsSome.Should().BeFalse();
    }
}
