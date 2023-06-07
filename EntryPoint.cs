using pomodoro_cli.Services;

namespace pomodoro_cli
{
    public class EntryPoint
    {
        private readonly ITestService testService;

        public EntryPoint(ITestService testService)
        {
            this.testService = testService;
        }

        public void Execute()
        {
            this.testService.Test();
        }
    }
}
