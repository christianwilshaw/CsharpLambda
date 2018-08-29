namespace AwsDotnetCsharp
{
    public static class BootStrapper
    {
        public static IService CreateInstance()
        {
            var messageToReturn = LambdaConfiguration.Instance["AnotherSecret"];

            return new Service(messageToReturn);
        }
    }
}
