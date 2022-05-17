namespace MemoryAllocations;

public record Person(string Name, DateTime BirthDay, List<string> Contacts)
{
    public Person(string name, DateTime birthDay, int numberOfContacts = 0) : this(name, birthDay, new List<string>(numberOfContacts))
    {
        if (numberOfContacts > 0)
        {
            FillContacts(numberOfContacts);
        }
    }

    public int YearsOldIn(DateTime date)
    {
        return (date - BirthDay).Days / 365;
    }

    private void FillContacts(int count = 10)
    {
        var contacts = Enumerable.Range(0, count).Select(i => $"Contact {i}");

        foreach (var c in contacts)
        {
            Contacts.Add(c);
        }
    }
}