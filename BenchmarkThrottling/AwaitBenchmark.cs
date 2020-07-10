using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace BenchmarkThrottling
{
    [KeepBenchmarkFiles]
    [AsciiDocExporter]
    [CsvExporter]
    [CsvMeasurementsExporter]
    [HtmlExporter]
    [PlainExporter]
    [JsonExporterAttribute.Brief]
    [JsonExporterAttribute.BriefCompressed]
    [JsonExporterAttribute.Full]
    [JsonExporterAttribute.FullCompressed]
    [MarkdownExporterAttribute.Default]
    [MarkdownExporterAttribute.GitHub]
    [MarkdownExporterAttribute.StackOverflow]
    [MarkdownExporterAttribute.Atlassian]
    [XmlExporterAttribute.Brief]
    [XmlExporterAttribute.BriefCompressed]
    [XmlExporterAttribute.Full]
    [XmlExporterAttribute.FullCompressed]
    public class AwaitBenchmark
    {
        private const int SIZE = 100;

        [Benchmark]
        public async Task AwaitWhenAllWithThrottling()
        {
            var tasks = new List<Task>();
            int timeout = 1;

            for (int i = 0; i < SIZE; i++)
            {
                tasks.Add(new TaskBuilder().Create(1, ref timeout).Single());

                if (tasks.Count == 10)
                {
                    await Task.WhenAll(tasks);
                    tasks.Clear();
                }
            }

            await Task.WhenAll(tasks);
        }

        [Benchmark]
        public async Task AwaitWhenAnyWithThrottling()
        {
            var tasks = new List<Task>();
            int timeout = 1;

            for (int i = 0; i < SIZE; i++)
            {
                tasks.Add(new TaskBuilder().Create(1, ref timeout).Single());

                if (tasks.Count == 10)
                {
                    var taskCompleted = await Task.WhenAny(tasks);
                    tasks.Remove(taskCompleted);
                }
            }

            await Task.WhenAll(tasks);
        }

        [Benchmark]
        public async Task AwaitWhenAnyAndCompletedWithThrottling()
        {
            var tasks = new List<Task>();
            int timeout = 1;

            for (int i = 0; i < SIZE; i++)
            {
                tasks.Add(new TaskBuilder().Create(1, ref timeout).Single());

                if (tasks.Count == 10)
                {
                    await Task.WhenAny(tasks);
                    tasks.RemoveAll(x => x.IsCompleted);
                }
            }

            await Task.WhenAll(tasks);
        }

        [Benchmark]
        public async Task AwaitWithoutThrottling()
        {
            int timeout = 1;

            foreach (var task in new TaskBuilder().Create(SIZE, ref timeout))
            {
                await task;
            }
        }
    }
}