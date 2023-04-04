using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using Xunit.Abstractions;

namespace TestePerfomance.Test
{
    public class PerformanceTests
    {
        private readonly ITestOutputHelper _output;

        public PerformanceTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TesteDePerfomanceDeLoop()
        {
            var logger = new AccumulationLogger();

            var config = ManualConfig.Create(DefaultConfig.Instance)
                .AddLogger(logger)
                .WithOptions(ConfigOptions.DisableOptimizationsValidator);
            BenchmarkRunner.Run<ServiceDemo>(config);

            // write benchmark summary
            _output.WriteLine(logger.GetLog());
        }
    }
}