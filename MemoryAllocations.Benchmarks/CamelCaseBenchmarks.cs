using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;

namespace MemoryAllocations.Benchmarks;

[MemoryDiagnoser]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
public class CamelCaseBenchmarks
{
    [Benchmark]
    public void StackAlloc()
    {
        "HelLo WoRlD I am a string".CamelCaseStackAlloc();
    }
    
    [Benchmark]
    public void Linq()
    {
        "HelLo WoRlD I am a string".CamelCaseLinq();
    }
}