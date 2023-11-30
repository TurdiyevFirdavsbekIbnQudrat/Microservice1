
namespace byyGateWay.API
{
    public class BackgroundServiceTest : IHostedService
    {
        private readonly ILogger<BackgroundServiceTest> _logger;

        public BackgroundServiceTest(ILogger<BackgroundServiceTest> logger)
        {
            _logger = logger;
        }

        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    var period = new PeriodicTimer(TimeSpan.FromSeconds(5));
        //    while (await period.WaitForNextTickAsync(stoppingToken))
        //    {
        //        Console.WriteLine("Ishlayapti");
        //    }
        //}
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StartAsync");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"StopAsync");
            return Task.CompletedTask;
        }
    }
}
