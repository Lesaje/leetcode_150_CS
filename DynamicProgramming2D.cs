namespace Leetcode150;

public class DynamicProgramming2D
{
    public int UniquePaths(int m, int n)
    {
        var pathsNumbers = new Dictionary<(int, int), int>();
        
        int loop(int x, int y)
        {
            if (pathsNumbers.ContainsKey((x, y))) return pathsNumbers[(x, y)];
            
            if (x == m - 1 && y == n - 1) return 1;
            if (x == m - 1) return loop(x, y + 1);
            if (y == n - 1) return loop(x + 1, y);

            pathsNumbers[(x, y)] = loop(x + 1, y) + loop(x, y + 1);
            return pathsNumbers[(x, y)];
        }
        
        return loop(0, 0);
    }
    
    public int LongestCommonSubsequence(string text1, string text2)
    {
        if (text2.Length > text1.Length) (text1, text2) = (text2, text1);
        
        var dp = new Dictionary<(int, int), int>();
        
        int loop(int index1, int index2)
        {
            if (index1 == text1.Length || index2 == text2.Length) return 0;
            if (text1[index1] == text2[index2]) return 1 + loop(index1 + 1, index2 + 1);

            if (!dp.ContainsKey((index1, index2)))
            {
                dp[(index1, index2)] = 
                    Math.Max(loop(index1 + 1, index2), loop(index1, index2+1));
            }
            return dp[(index1, index2)];
        }

        return loop(0, 0);
    }
}