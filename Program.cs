namespace pomodoro_cli
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Debug;
    using pomodoro_cli.Services;

    internal class Program
    {
        static void Main(string[] args)
        {
            // https://siderite.dev/blog/creating-console-app-with-dependency-injection-in-#at1772592574
            Host.CreateDefaultBuilder()
                ?.ConfigureServices(ConfigureServices)
                ?.ConfigureLogging((hostContext, loggingBuilder) =>
                {
                    loggingBuilder.AddConfiguration(hostContext.Configuration);
                    loggingBuilder.ClearProviders();

                    loggingBuilder.AddDebug();
                    loggingBuilder.AddConsole();
                })
                ?.ConfigureServices(services => services.AddSingleton<EntryPoint>())
                ?.Build()
                ?.Services?.GetService<EntryPoint>()?.Execute();
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton<ITestService, TestService>();
        }
    }
}