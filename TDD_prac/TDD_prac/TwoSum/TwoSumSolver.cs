namespace TDD_prac.TwoSum;

public class TwoSumSolver
{
    private readonly Dictionary<int, int> _indexes = new();

    public int[] GetIndexesForTwoSum(int[] ints, int sum)
    {
        for (var curIndex = 0; curIndex < ints.Length; curIndex++)
        {
            var curValue = ints[curIndex];
            var complement = sum - curValue;
            if (IsComplementExist(complement, out var complementIndex))
            {
                return [complementIndex, curIndex];
            }
            _indexes[curValue] = curIndex;
        }
        throw new ArgumentException("No two sum solution");
    }

    private bool IsComplementExist(int complement, out int value)
    {
        return _indexes.TryGetValue(complement, out value);
    }
}