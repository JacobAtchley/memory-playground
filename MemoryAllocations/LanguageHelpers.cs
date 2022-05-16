namespace MemoryAllocations;

public static class LanguageHelpers
{
    public static string CamelCaseStackAlloc(this string str)
    {
        Span<char> chars = stackalloc char[str.Count(char.IsLetterOrDigit)];

        var writeIndex = 0;
        for (var i = 0; i < str.Length; i++)
        {
            if (!char.IsLetterOrDigit(str[i]))
            {
                continue;
            }
            
            if (i == 0)
            {
                chars[writeIndex] = char.IsUpper(str[i]) ? char.ToLower(str[i]) : str[i];
                writeIndex++;
                continue;
            }

            if (!char.IsLetterOrDigit(str[i - 1]))
            {
                chars[writeIndex] = char.ToUpper(str[i]);
                writeIndex++;
                continue;
            }
            
            chars[writeIndex] = char.ToLower(str[i]);
            writeIndex++;
        }
        
        return new string(chars);
    }
    
    public static string CamelCaseLinq(this string str)
    {
        var chars = str.Split(' ')
            .Select(x => char.IsLetter(x[0]) ? char.ToUpper(x[0]) + x[1..].ToLower() : x.ToLower())
            .SelectMany(x => x)
            .Where(char.IsLetter)
            .ToArray();
        
        chars[0] = char.ToLower(chars[0]);
        
        return new string(chars.ToArray());
    }
}