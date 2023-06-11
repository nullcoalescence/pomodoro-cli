using pomodoro_cli.Services;

namespace pomodoro_cli
{
    public class EntryPoint
    {
        private readonly ITimerService timerService;

        public EntryPoint(ITimerService timerService)
        {
            this.timerService = timerService;
        }

        public void Execute()
        {
            // Prompt user to enter a time then start timer
            Console.WriteLine("Enter a time (in minutes) for timer.");
            
            var time = Console.ReadLine().Trim();
            if (!int.TryParse(time, out var val))
            {
                throw new Exception("Not an integer");
            }

            var ms = val * 6000;

            // Start timer
            this.timerService.StartTimer(ms);
            
        }
    }
}
