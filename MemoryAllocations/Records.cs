namespace MemoryAllocations;

public record Person(string Name, DateTime BirthDay)
{
     public int YearsOldIn(DateTime date) => (date - BirthDay).Days / 365;
}

public record PersonAndDate(Person Person, DateTime Date)
{
}