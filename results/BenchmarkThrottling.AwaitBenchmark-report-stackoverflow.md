
    BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.900 (1909/November2018Update/19H2)
    Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
    .NET Core SDK=3.1.301
      [Host]     : .NET Core 3.1.5 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.27001), X64 RyuJIT
      DefaultJob : .NET Core 3.1.5 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.27001), X64 RyuJIT


                                     Method |     Mean |   Error |  StdDev |
    --------------------------------------- |---------:|--------:|--------:|
                 AwaitWhenAllWithThrottling | 100.07 s | 0.043 s | 0.040 s |
                 AwaitWhenAnyWithThrottling |  60.11 s | 0.017 s | 0.016 s |
     AwaitWhenAnyAndCompletedWithThrottling |  60.10 s | 0.013 s | 0.012 s |
                     AwaitWithoutThrottling |  10.01 s | 0.008 s | 0.008 s |
