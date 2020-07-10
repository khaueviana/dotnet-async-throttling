using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace BenchmarkThrottling
{
    class Program
    {
        static async Task Main(string[] args)
        {
            BenchmarkRunner.Run<AwaitBenchmark>();
            
            Console.ReadKey();

            //await new AwaitBenchmark().AwaitWhenAnyAndCompletedWithThrottling();
        }
    }
}
