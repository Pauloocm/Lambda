
using Aws.Lambda.Platform.Application;
using NSubstitute;
using NUnit.Framework;

namespace Lambda.Tests;


[TestFixture]
public class LambdaSnsAppServiceTest
{
    [SetUp]
    public void Setup()
    {
        LambdaSnsAppService lambdaAppService = new LambdaSnsAppService();
    }

    [Test]
    public void Should_Thrown_When_Credentials_Is_Null()
    {

    }
}

