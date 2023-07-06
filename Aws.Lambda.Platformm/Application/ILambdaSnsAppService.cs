using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aws.Lambda.Platform.Application
{
    public interface ILambdaSnsAppService
    {
        public Task SendMessage(string message);

        public string ToUpperString(string message);
    }
}
