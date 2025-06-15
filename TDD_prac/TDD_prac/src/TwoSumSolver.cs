namespace TDD_prac;

public class TwoSumSolver
{
    public int[] GetIndexesForTwoSum(int[] ints, int i)
    {
        var indexes = new Dictionary<int, int>();
        for (var j = 0; j < ints.Length; j++)
        {
            var complement = i - ints[j];
            if (indexes.TryGetValue(complement, out var value))
            {
                return [value, j];
            }
            indexes[ints[j]] = j;
        }
        throw new ArgumentException("No two sum solution");
    }
}