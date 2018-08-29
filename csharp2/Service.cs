using System;
using System.Threading.Tasks;

namespace AwsDotnetCsharp
{
    public class Service : IService
    {
        private readonly string messageToReturn;

        public Service(string messageToReturn)
        {
            this.messageToReturn = messageToReturn;
        }

        //Just returns the message the service was configured with (not really an async operation)
        public async Task<string> GetMessageToReturn() => this.messageToReturn;

        }
}
