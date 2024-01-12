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
        sut.FizzBuzz().Should().Be("1");
    }
    
    [Test]
    public void shgfdghdfg()
    {
        var sut = new Output(2);
        sut.FizzBuzz().Should().Be("2");
    }
    
    [Test]
    public void sdfghdfghd()
    {
        var sut = new Output(3);
        sut.FizzBuzz().Should().Be("Fizz");
    }
    
    [Test]
    public void hgjfghjfgh()
    {
        var sut = new Output(6);
        sut.FizzBuzz().Should().Be("Fizz");
    }
    
}

public class Output
{
    public string output;
    private int value;

    public Output(int value)
    {
        this.value = value;
        output = FizzBuzz(value);
    }

    public string FizzBuzz(int value)
    {
        if(value % 3 == 0)
        {
            return "Fizz";
        }
        return value.ToString();
    }
    public string FizzBuzz()
    {
        if(value % 3 == 0)
        {
            return "Fizz";
        }
        return value.ToString();
    }
}