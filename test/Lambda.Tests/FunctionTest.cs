using Aws.Lambda.Platform.Application;
using NUnit.Framework;
using NSubstitute;
using Amazon.Lambda.TestUtilities;

namespace Lambda.Tests;

[TestFixture]
public class FunctionTest
{
    public FunctionTest()
    {
        Console.WriteLine("teste");
    }

    [SetUp]
    public void Setup()
    {
        lambdaSnsAppServiceMock = Substitute.For<ILambdaSnsAppService>();
    }

    private ILambdaSnsAppService lambdaSnsAppServiceMock = null!;

    [Test]
    public void TestToUpperFunction()
    {
         
        // Invoke the lambda function and confirm the string was upper cased.
        var function = new Function();
        var context = new TestLambdaContext();
        var upperCase = function.Handler("PAULINHO", context);

        Assert.That(upperCase, Is.SameAs("PAULINHO"));
    }

    [Test]
    public async Task Should_Return_Ok()
    {
        var function = new Function(lambdaSnsAppServiceMock);
        var context = new TestLambdaContext();
        var input = "Mensagem teste";
        var result = await function.SendSMSMessage(input, context);

        Assert.That(result, Is.Not.Null.Or.Empty);
        Assert.That(result, Is.EqualTo("Enviado"));
    }

    [Test]
    public async Task Should_Throw_When_Input_Or_Context_Is_Null()
    {
        var function = new Function(lambdaSnsAppServiceMock);
        var context = new TestLambdaContext();

        Assert.ThrowsAsync<ArgumentNullException>(() => function.SendSMSMessage(null, context));
        Assert.ThrowsAsync<ArgumentNullException>(() => function.SendSMSMessage("teste", null));
    }
}
