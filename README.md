# dotnet-async-throttling

The goal is to find the fastest way to perform multiple tasks in parallel using throttling.

## Scenarios with Throttling

- Await.WhenAll - awaiting all the tasks and removing them from the task list at each throttle cicle
- Await.WhenAny() - awaiting any task and removing only one completed task at each throttle cicle
- Await.WhenAny() - awaiting any task and removing all completed tasks at each throttle cicle

**Parameters**

```
- Taks Counts = 100
    - with Timeout.Delay(1..10 in a row)
- Throttling = 10 tasks  
```

## Scenario without Throttling

- AwaitWithoutThrottling

**Parameters**

```
- Taks Counts = 100
    - with Timeout.Delay(1..10 in a row)
```
## Results

![alt text](results/result.png)

*Benchmark using: https://github.com/dotnet/BenchmarkDotNet*