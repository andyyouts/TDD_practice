namespace TDD_prac.CountDuplicates;

public class DuplicatesCounter
{
    private readonly Dictionary<char, int> _charCounter = new();

    public int CountDuplicatesByForEach(string input)
    {
        var duplicateCounts = 0;

        foreach (var lowerCharacter in input.Select(char.ToLower))
        {
            if (!_charCounter.TryGetValue(lowerCharacter, out var value))
            {
                _charCounter.Add(lowerCharacter, 1);
            }
            
            else if (value == 1)
            {
                _charCounter[lowerCharacter]++;
                duplicateCounts++;
            }
        }
        return duplicateCounts;
    }

    public int CountDuplicatesByLinq(string input)
    {
        return input.GroupBy(char.ToLower).Where(g => g.Count() > 1).Select(g => g.Key).Count();
    }
}