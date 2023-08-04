namespace Leetcode150;

public class BitManipulation
{
    public int SingleNumber(int[] nums)
    {
        var ans = 0;
        foreach (var i in nums)
        {
            ans = ans ^ i;
        }

        return ans;
    }
    
    public int HammingWeight(uint n)
    {
        var res = 0;
        while (n != 0)
        {
            res += unchecked((int)(n % 2));
            n >>= 1;
        }

        return res;
    }

    public int[] CountBits(int n)
    {
        var arr = new int[n+1];

        for (var i = 0; i <= n; i++)
        {
            arr[i] = HammingWeight(unchecked((uint)i));
        }

        return arr;
    }
}