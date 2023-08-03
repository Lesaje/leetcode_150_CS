namespace Leetcode150;

public class BackTracking
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var res = new List<IList<int>>();
        var subset = new List<int>();
        
        void Dfs(int i)
        {
            if (i >= nums.Length)
            {
                res.Add(subset.GetRange(0, subset.Count));
                return;
            }
            
            subset.Add(nums[i]);
            Dfs(i + 1);

            subset.Remove(nums[i]);
            Dfs(i + 1);
        }
        
        Dfs(0);
        return res;
    }
}