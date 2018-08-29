using Microsoft.Extensions.Configuration;
using System.IO;

namespace AwsDotnetCsharp
{
    public static  class LambdaConfiguration
    {
        private static IConfigurationRoot instance = null;
        public static IConfigurationRoot Instance
        {
            get
            {
                return instance ?? (instance = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("./config/appsettings.json")
                    .AddJsonFile("./secrets/secretsettings.json")
                    .Build());
            }
        }
        public static string FetchEnVariable(string variableName)
        {
            return System.Environment.GetEnvironmentVariable(variableName);
        }
    }
}
