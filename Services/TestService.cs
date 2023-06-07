using Microsoft.Extensions.Logging;

namespace pomodoro_cli.Services
{
    public class TestService : ITestService
    {
        private readonly ILogger<TestService> logger;

        public TestService(ILogger<TestService> logger) 
        {
            this.logger = logger;
        }

        public void Test()
        {
            logger.LogInformation("TestService: Test");
        }
    }
}
