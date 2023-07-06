using Amazon.Lambda.Core;
using Aws.Lambda.Platform.Application;



// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]


namespace Lambda;

public class Function
{

    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    /// 

    private ILambdaSnsAppService snsAppService;
    public Function()
    {
        this.snsAppService = new LambdaSnsAppService();
    }

    public Function(ILambdaSnsAppService lambdaAppService)
    {
        this.snsAppService = lambdaAppService;
    }

    public string Handler(string input, ILambdaContext context)
    {
        return snsAppService.ToUpperString(input);
    }

    public async Task<string> SendSMSMessage(string input, ILambdaContext context)
    {
        if(input == null)
            throw new ArgumentNullException("input");

        if(context == null) 
            throw new ArgumentNullException("context");

        await snsAppService.SendMessage(input);

        return "Enviado";
    }


}
