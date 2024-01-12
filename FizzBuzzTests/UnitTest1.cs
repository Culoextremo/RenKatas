using FluentAssertions;
using FluentAssertions.Execution;
using static FizzBuzz;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void dsfghfdsgh()
    {
        FizzBuzzOf(1).Should().Be("1");
    }
    
    [Test]
    public void shgfdghdfg()
    {
        FizzBuzzOf(2).Should().Be("2");
    }
    
    [Test]
    public void sdfghdfghd()
    {
        FizzBuzzOf(3).Should().Be("Fizz");
    }
    
    [Test]
    public void hgjfghjfgh()
    {
        FizzBuzzOf(6).Should().Be("Fizz");
    }
    
    [Test]
    public void dfghfdgh()
    {
        FizzBuzzOf(10).Should().Be("Buzz");
    }
    
    [Test]
    public void fgjgfhjfgh()
    {
        FizzBuzzOf(15).Should().Be("FizzBuzz!");
    }
}