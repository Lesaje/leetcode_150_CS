using System.Collections;

namespace Leetcode150;

public static class DynamicProgramming1D
{
    public static int ClimbStairs(int n)
    {
        if (n == 1) return 1;
        if (n == 2) return 2;
        
        var answers = new int[n];
        answers[n - 1] = 1;
        answers[n - 2] = 2;

        for (var i = n - 3; i >= 0; i--)
        {
            answers[i] = answers[i + 1] + answers[i + 2];
        }

        return answers[0];
    }


    public static int MinCostClimbingStairs(int[] cost)
    {
        var minCost = new int[cost.Length];
        minCost[0] = cost[0];
        minCost[1] = cost[1];
            
        int loop(int n)
        {
            if (n == cost.Length) return Math.Min(minCost[n - 1], minCost[n - 2]);
            minCost[n] = Math.Min(minCost[n - 1], minCost[n - 2]) + cost[n];
            return loop(n + 1);
        }

        return loop(2);
    }

    public static int Rob(int[] nums)
    {
        var length = nums.Length;
        var costs = new Dictionary<int, int>();
        
        int loop(int n)
        {
            if (n >= length) return 0;
            
            if (!costs.ContainsKey(n))
            {
                costs[n] = Math.Max(nums[n] + loop(n + 2), loop(n + 1));
            }
            return costs[n];
        }

        return loop(0);
    }

    public static int RobCircle(int[] nums)
    {
        var costsFirst = new Dictionary<int, int>();
        var costsLast = new Dictionary<int, int>();

        var numsFirst = nums.Take(nums.Length - 1).ToArray();
        var numsLast = nums.TakeLast(nums.Length - 1).ToArray();

        if (nums.Length == 1) return nums[0];
        
        int loop(int n, int[] nums, Dictionary<int, int> costs)
        {
            var length = nums.Length;
            
            if (n >= length) return 0;
            
            if (!costs.ContainsKey(n))
            {
                costs[n] = Math.Max(nums[n] + loop(n + 2, nums, costs), loop(n + 1, nums, costs));
            }
            return costs[n];
        }

        return Math.Max(loop(0, numsFirst, costsFirst), loop(0, numsLast, costsLast));
    }


    public static string LongestPalindrome(string s)
    {
        return "";
    }
}