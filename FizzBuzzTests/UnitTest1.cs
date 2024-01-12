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
    
    [Test]
    public void sdfghdfghd()
    {
        var sut = new Output(3);
        sut.value.Should().Be("Fizz");
    }
    
    [Test]
    public void hgjfghjfgh()
    {
        var sut = new Output(6);
        sut.value.Should().Be("Fizz");
    }
    
}

public class Output
{
    public string value;

    public Output(int value)
    {
        if(value % 3 == 0)
        {
            this.value = "Fizz";
        }
        else
        {
            this.value = value.ToString();
        }
    }
}