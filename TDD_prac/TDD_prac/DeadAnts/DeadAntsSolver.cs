namespace TDD_prac.DeadAnts;

public class DeadAntsSolver
{
    private const string ValidAntValue = "ant";

    private readonly Dictionary<char, int> _letterCounts = new()
    {
        { 'a', 0 },
        { 'n', 0 },
        { 't', 0 }
    };

    public int CountDeadAnts(string antsString)
    {
        if (!IsValidAntString(antsString))
        {
            return 0;
        }

        var antBits = antsString.Split('.', StringSplitOptions.RemoveEmptyEntries);

        CountScatteredBits(antBits);

        return _letterCounts.Values.Max();
    }

    private static bool IsValidAntString(string antsString)
    {
        return !string.IsNullOrWhiteSpace(antsString);
    }

    private void CountScatteredBits(string[] antBits)
    {
        foreach (var antBit in antBits)
        {
            if (IsCurrentPartValid(antBit))
            {
                continue;
            }
            
            var scatteredBits = GetScatteredBits(antBit);

            foreach (var character in scatteredBits)
            {
                UpdateAntCount(character);
            }
        }
    }

    private static string GetScatteredBits(string antBit)
    {
        return antBit.Contains(ValidAntValue)
            ? antBit.Replace(ValidAntValue, "")
            : antBit;
    }

    private static bool IsCurrentPartValid(string antBit)
    {
        return antBit == ValidAntValue;
    }

    private void UpdateAntCount(char character)
    {
        if (!_letterCounts.TryGetValue(character, out var value))
        {
            throw new Exception("Only 'ant' characters are allowed.");
        }

        _letterCounts[character] = ++value;
    }
}