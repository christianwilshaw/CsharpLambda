
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using System.Threading.Tasks;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AwsDotnetCsharp
{
    public class Function
    {
        private readonly IService exampleService;
        private readonly string anotherMessageToReturn;
        private readonly string someEnvironmentVariable;

        //using default constructor to invoke the overloaded constructor with defaults
        public Function() : this (BootStrapper.CreateInstance(),LambdaConfiguration.Instance["DefaultMessage"],LambdaConfiguration.FetchEnVariable("")) { }

        //constructor injection for tests.
        public Function(IService exampleService, string anotherMessageToReturn, string someEnvironmentVariable)
        {
            this.exampleService = exampleService;
            this.anotherMessageToReturn = anotherMessageToReturn;
            this.someEnvironmentVariable = someEnvironmentVariable;
        }

        public async Task<Result> Handler(Event lambdaEvent)  //Lambda handler methods can be marked as async 
        {
            var message = await this.exampleService.GetMessageToReturn();

            return new Result
            {
                MyProperty = lambdaEvent.MyProperty,
                Message = message,
                AnotherMessage = this.anotherMessageToReturn
            };
        }


        public APIGatewayProxyResponse Hello(APIGatewayProxyRequest apigProxyEvent, ILambdaContext context)
       {
           return new APIGatewayProxyResponse {
             StatusCode = 200,
             Body = "hello"
           };
       }
    }
}