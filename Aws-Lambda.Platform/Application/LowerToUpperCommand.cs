using Amazon.Lambda.Core;

namespace Aws_Lambda.Platform.Application
{
    public class LowerToUpperCommand
    {
        protected LowerToUpperCommand()
        {

        }
        public static string LowerToUpper(string input, ILambdaContext context)
        {
            return input.ToUpper();
        }
    }
}
