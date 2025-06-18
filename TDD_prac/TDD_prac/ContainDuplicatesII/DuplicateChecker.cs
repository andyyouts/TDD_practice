namespace TDD_prac.ContainDuplicatesII;

public class DuplicateChecker
{
    public bool CheckForDuplicates(int[] nums, int k)
    {
        if (nums.Length == 0 || k < 0)
        {
            throw new ArgumentException("invalid input");
        }

        var indexMap = new Dictionary<int, int>();

        for (var j = 0; j < nums.Length; j++)
        {
            if (indexMap.TryGetValue(nums[j], out var prevIndex))
            {
                if (Math.Abs(j - prevIndex) <= k)
                {
                    return true;
                }
            }

            indexMap[nums[j]] = j;
        }

        return false;
    }
}