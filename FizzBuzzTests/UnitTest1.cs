using FluentAssertions;
using FluentAssertions.Execution;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void dsfghfdsgh()
    {
        var sut = new Output(1);
        sut.value.Should().Be("1");
    }
    
    [Test]
    public void shgfdghdfg()
    {
        var sut = new Output(2);
        sut.value.Should().Be("2");
    }
    
    
}

public class Output
{
    public string value;

    public Output(int value)
    {
        this.value = value.ToString();
    }
}