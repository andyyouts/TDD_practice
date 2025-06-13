namespace TDD_prac;

public class DuplicatesCounter
{
    private readonly Dictionary<char, int> _charCounter = new();

    public int CountDuplicates(string input)
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
}