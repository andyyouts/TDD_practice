namespace TDD_prac.ThreeSum;

public class ThreeSumSolver
{
    public IList<IList<int>> SolveThreeSum(int[]? ints, bool sortingAscending = true)
    {
        ArgumentNullException.ThrowIfNull(ints);

        if (HasEnoughElements(ints))
        {
            return new List<IList<int>>();
        }
        
        return sortingAscending ? SolveByDescending(ints) : SolveByAscending(ints);    
    }

    private static bool HasEnoughElements(int[] ints)
    {
        return ints.Length < 3;
    }

    private static IList<IList<int>> SolveByAscending(int[] ints)
    {
        Array.Sort(ints);
        
        return CalculateThreeSumCombinations(ints);
    }

    private static bool SameValueAsLastElement(int[] ints, int i)
    {
        return i > 0 && ints[i] == ints[i - 1];
    }

    private static IList<IList<int>> SolveByDescending(int[] ints)
    {
        ints = ints.OrderDescending().ToArray();
        
        return CalculateThreeSumCombinations(ints);
    }

    private static IList<IList<int>> CalculateThreeSumCombinations(int[] ints)
    {
        List<IList<int>> result = [];

        for (var curIndex = 0; curIndex < ints.Length - 2; curIndex++)
        {
            if (SameValueAsLastElement(ints, curIndex))
            {
                continue;
            }

            var left = curIndex + 1;
            var right = ints.Length - 1;

            while (left < right)
            {
                var sum = ints[curIndex] + ints[left] + ints[right];

                switch (sum)
                {
                    case 0:
                    {
                        result.Add(new List<int> { ints[curIndex], ints[left], ints[right] });
                        while (left < right && ints[left] == ints[left + 1])
                        {
                            left++; 
                        }

                        while (left < right && ints[right] == ints[right - 1])
                        {
                            right--; 
                        }

                        left++;
                        right--;
                        break;
                    }
                    case > 0:
                        left++;
                        break;
                    default:
                        right--;
                        break;
                }
            }
        }

        return result;
    }
}