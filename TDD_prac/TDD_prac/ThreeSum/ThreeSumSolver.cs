namespace TDD_prac.ThreeSum;

public class ThreeSumSolver
{
    public IList<IList<int>> SolveThreeSum(int[]? ints, bool ascending = true)
    {
        ArgumentNullException.ThrowIfNull(ints);

        if (ints.Length < 3)
        {
            return new List<IList<int>>();
        }
        
        return ascending ? SolveByDescending(ints) : SolveByAscending(ints);    
    }

    private IList<IList<int>> SolveByAscending(int[] ints)
    {
        var result = new List<IList<int>>();

        Array.Sort(ints);
        
        for (var i = 0; i < ints.Length - 2; i++)
        {
            if (i > 0 && ints[i] == ints[i - 1])
            {
                continue;
            }

            var left = i + 1;
            var right = ints.Length - 1;

            while (left < right)
            {
                var sum = ints[i] + ints[left] + ints[right];

                switch (sum)
                {
                    case 0:
                    {
                        result.Add(new List<int> { ints[i], ints[left], ints[right] });
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
                    case < 0:
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
    
    private IList<IList<int>> SolveByDescending(int[] ints)
    {
        var result = new List<IList<int>>();

        ints = ints.OrderDescending().ToArray();
        
        for (var i = 0; i < ints.Length - 2; i++)
        {
            if (i > 0 && ints[i] == ints[i - 1])
            {
                continue;
            }

            var left = i + 1;
            var right = ints.Length - 1;

            while (left < right)
            {
                var sum = ints[i] + ints[left] + ints[right];

                switch (sum)
                {
                    case 0:
                    {
                        result.Add(new List<int> { ints[i], ints[left], ints[right] });
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