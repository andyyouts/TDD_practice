using System.Diagnostics.Metrics;

namespace TDD_prac;

public class DeadAntsSolver
{
    private readonly Dictionary<char, int> _letterCounts = new()
    {
        { 'a', 0 },
        { 'n', 0 },
        { 't', 0 }
    };

    public int CountDeadAnts(string antsString)
    {
        if (string.IsNullOrWhiteSpace(antsString))
        {
            return 0;
        }

        var antBits = antsString.Split('.', StringSplitOptions.RemoveEmptyEntries);

        CountScatteredBits(antBits);

        return _letterCounts.Values.Max();
    }

    private void CountScatteredBits(string[] antBits)
    {
        foreach (var antBit in antBits)
        {
            if (antBit == "ant")
            {
                continue;
            }
            
            var scatteredBits = antBit.Contains("ant")
                ? antBit.Replace("ant", "")
                : antBit;

            foreach (var character in scatteredBits)
            {
                if (!_letterCounts.TryGetValue(character, out var value))
                {
                    throw new Exception("Only 'ant' characters are allowed.");
                }

                _letterCounts[character] = ++value;
            }
        }
    }
}