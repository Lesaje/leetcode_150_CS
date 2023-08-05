namespace Leetcode150;

public static class Greedy
{
    public static int MaxSubArray(int[] nums)
    {
        var ans = Int32.MinValue;
        var cur = 0;
        
        foreach (var i in nums)
        {
            cur = Math.Max(i, cur + i);
            ans = Math.Max(ans, cur);
        }

        return ans;
    }
    
    public static bool CanJump(int[] nums)
    {
        var index = nums.Length - 1;
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] + i >= index)
            {
                index = i;
            }
        }

        return index <= 0; 
    }
    
    public static int Jump(int[] nums)
    {
        var step = 0;
        var curEnd = 0;
        var curFastJump = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            curFastJump = Math.Max(nums[i] + i, curFastJump);
            if (i == curEnd)
            {
                step++;
                curEnd = curFastJump;
            }
        }
        return step;
    }
    
}