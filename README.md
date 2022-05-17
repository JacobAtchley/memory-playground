# memory-playground

This is a playground project for experimenting with memory allocations, boxing, stacks, heaps, etc.
There is a benchmarking project you can run benchmarks against.

``dotnet run --project MemoryAllocations.Benchmarks.csproj -c Release``

here are some outputs from previous runs:

## Boxing

``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.3.1 (21E258) [Darwin 21.4.0]
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
|  Method |      Mean |     Error |    StdDev |    Median |  Gen 0 | Allocated |
|-------- |----------:|----------:|----------:|----------:|-------:|----------:|
|   Boxed | 4.8096 ns | 0.2118 ns | 0.6211 ns | 4.6317 ns | 0.0051 |      24 B |
| UnBoxed | 0.0176 ns | 0.0189 ns | 0.0147 ns | 0.0225 ns |      - |         - |


## Camel Case

``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.3.1 (21E258) [Darwin 21.4.0]
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
|     Method |       Mean |    Error |   StdDev |     Median |  Gen 0 | Allocated |
|----------- |-----------:|---------:|---------:|-----------:|-------:|----------:|
| StackAlloc |   558.4 ns | 11.14 ns | 29.53 ns |   547.1 ns | 0.0334 |     160 B |
|       Linq | 1,328.7 ns | 31.62 ns | 91.24 ns | 1,307.9 ns | 0.3300 |   1,560 B |


## Dictionary
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.3.1 (21E258) [Darwin 21.4.0]
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
|           Method |     Mean |   Error |   StdDev |  Gen 0 |  Gen 1 | Allocated |
|----------------- |---------:|--------:|---------:|-------:|-------:|----------:|
|    Benchmark_Bad | 475.5 ns | 4.77 ns |  3.72 ns | 0.2394 |      - |      1 KB |
| Benchmark_Better | 483.6 ns | 9.49 ns | 27.23 ns | 0.2208 | 0.0005 |      1 KB |
|   Benchmark_Best | 476.4 ns | 9.44 ns | 18.64 ns | 0.2203 |      - |      1 KB |