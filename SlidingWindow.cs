
public static class SlidingWindow
{
    public static int MaxProfit(int[] prices)
    {
        GC.Collect();
        var n = prices.Length;
        var dp = new int[n, 2];

        dp[0, 0] = -prices[0];
        dp[0, 1] = 0;  
        
        for (int i = 1; i < n; i++) 
        {
            dp[i, 0] = Math.Max(dp[i - 1, 0], -prices[i]);    
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] + prices[i]);
        }

        return Math.Max(dp[n-1, 0], dp[n-1, 1]);
    }
}