using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;

namespace MemoryAllocations.Benchmarks;


[MemoryDiagnoser]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
public class DictionaryBenchmarks
{
        [Benchmark]
        public void Benchmark_Bad()
        {
            ConcurrentDictionary<PersonAndDate, string> cache = new ();
            var dateToCompare = new DateTime(1997, 12, 25);
            var person = new Person("Jacob", new DateTime(1987, 12, 28));
        
            cache.GetOrAdd(
                new PersonAndDate(person, dateToCompare), 
                key => $"{key.Person.Name} was {key.Person.YearsOldIn(dateToCompare)} year(s) old on {dateToCompare:d}");
        }

        [Benchmark]
        public void Benchmark_Better()
        {
            ConcurrentDictionary<PersonAndDate, string> cache = new ();
            var dateToCompare = new DateTime(1997, 12, 25);
            var person = new Person("Jacob", new DateTime(1987, 12, 28));
        
            cache.GetOrAdd(
                new PersonAndDate(person, dateToCompare), 
                static (key, args) => $"{key.Person.Name} was {key.Person.YearsOldIn(args)} year(s) old on {args:d}",
                dateToCompare);
        }

        [Benchmark]
        public void Benchmark_Best()
        {
            ConcurrentDictionary<PersonAndDate, string> cache = new ();
            var dateToCompare = new DateTime(1997, 12, 25);
            var person = new Person("Jacob", new DateTime(1987, 12, 28));
        

            cache.GetOrAdd(
                new PersonAndDate(person, dateToCompare),
                static key => $"{key.Person.Name} was {key.Person.YearsOldIn(key.Date)} year(s) old on {key.Date:d}");
        }
}