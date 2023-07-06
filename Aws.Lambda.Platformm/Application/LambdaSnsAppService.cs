using Amazon.SimpleNotificationService.Model;
using Amazon.SimpleNotificationService;
using Amazon;

namespace Aws.Lambda.Platform.Application
{
    public class LambdaSnsAppService : ILambdaSnsAppService
    {
        string acessKey = "AKIAR355CYXATICAOU74";
        string secretKey = "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";
        public async Task SendMessage(string message, string acessKey, string secretKey)
        {

            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(acessKey,secretKey);
            var snsClient = new AmazonSimpleNotificationServiceClient(awsCredentials, RegionEndpoint.SAEast1);

            var request = new PublishRequest
            {
                PhoneNumber = "+5571991433757", // Número de telefone de destino
                Message = message.ToUpper()

            };

            var response = await snsClient.PublishAsync(request);

            if(response.HttpStatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Erro ao enviar mensagem");
        }

        public string ToUpperString(string message)
        {
            return message.ToUpper();
        }
    }
}
