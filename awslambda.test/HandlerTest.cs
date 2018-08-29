using AwsDotnetCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace awslambda.test
{
    [TestClass]
    public class HandlerTest
    {
        [TestMethod]
        public async Task Handler_Returns_Message_From_Example_ServiceAsync()
        {
            var testMessage = "Hello, world!  Testing...";

            var exampleServiceMock = new Mock<IService>();

            exampleServiceMock.Setup(m => m.GetMessageToReturn())
                .Returns(Task.FromResult(testMessage));

            // here we use the overloaded ctor to inject mocks not sure there is much value in this test!!.
            var function = new Function(exampleServiceMock.Object, String.Empty, String.Empty);

            var result = await function.Handler(new Event());

            // assert that the message we told the service mock to return is equal to the one
            // the function returns in the result.
            Assert.AreEqual(testMessage, result.Message);
        }
        [TestMethod]
        public async Task Handler_Invokes_Through_Bootstrapper_Async()
        {
            // here we use the overloaded ctor to inject mocks not sure there is much value in this test!!.
            var function = new Function();

            var result = await function.Handler(new Event());

            //Work around to invoke the bootstrapper.
            Assert.IsNull(null);
        }
    }
}
