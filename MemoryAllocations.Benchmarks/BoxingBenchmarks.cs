using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;

namespace MemoryAllocations.Benchmarks;

[MemoryDiagnoser]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
public class BoxingBenchmarks
{
    [Benchmark]
    public void Boxed()
    {
        object first = 1;
        var second = 2;

        var result = (int)first + second;
    }

    [Benchmark]
    public void UnBoxed()
    {
        var first = 1;
        var second = 2;

        var result = first + second;
    }
}