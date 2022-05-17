using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;

namespace MemoryAllocations.Benchmarks;

[SuppressMessage("Performance", "CA1822:Mark members as static")]
[MemoryDiagnoser]
public class DictionaryBenchmarks
{
    /// <summary>
    /// A number of times to add a contact to the person record.
    /// The more contacts we add the more memory we allocate.
    /// </summary>
    private const int CONTACT_COUNT = 100;
    
    private static string GetPersonAgeString(Person person, DateTime dateToCompare) => 
        $"{person.Name} was {person.YearsOldIn(dateToCompare)} year(s) old on {dateToCompare:d}";

    [Benchmark]
    public void Dictionary_Closure_Allocation()
    {
        ConcurrentDictionary<Person, string> cache = new();
        var dateToCompare = new DateTime(1997, 12, 25);
        var person = new Person("Jacob", new DateTime(1987, 12, 28), CONTACT_COUNT);

        cache.GetOrAdd(person, key => GetPersonAgeString(key, dateToCompare));
    }

    [Benchmark]
    public void Dictionary_Function_Arg()
    {
        ConcurrentDictionary<Person, string> cache = new();
        var dateToCompare = new DateTime(1997, 12, 25);
        var person = new Person("Jacob", new DateTime(1987, 12, 28), CONTACT_COUNT);

        cache.GetOrAdd(
            person,
            static (key, args) => GetPersonAgeString(key, args),
            dateToCompare);
    }

    private record PersonAndDate(Person Person, DateTime Date);
    
    [Benchmark]
    public void Dictionary_Record_Key()
    {
        ConcurrentDictionary<PersonAndDate, string> cache = new();
        var dateToCompare = new DateTime(1997, 12, 25);
        var person = new Person("Jacob", new DateTime(1987, 12, 28), CONTACT_COUNT);

        cache.GetOrAdd(
            new PersonAndDate(person, dateToCompare),
            static key => GetPersonAgeString(key.Person, key.Date));
    }
}