using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchmarkThrottling
{
    public class TaskBuilder
    {
        public List<Task> Create(int size, ref int timeout)
        {
            var tasks = new List<Task>();

            for (int i = 0; i < size; i++)
            {
                tasks.Add(Task.Delay(TimeSpan.FromSeconds(timeout)));

                if (timeout == 10) { timeout = 0; }
                
                timeout++;
            }

            return tasks;
        }
    }
}