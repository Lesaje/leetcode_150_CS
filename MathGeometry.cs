using System.Numerics;

namespace Leetcode150;

public class MathGeometry
{
    public static IEnumerable<int> GetDigits(int source)
    {
        while (source > 0)
        {
            var digit = source % 10;
            source /= 10;
            yield return digit;
        }
    }
    
    public static bool IsHappy(int n)
    {
        var hashMap = new Dictionary<int, int>();

        while (n != 1)
        {
            if (hashMap.ContainsKey(n)) return false;
            else hashMap[n] = n;
            n = GetDigits(n).Select(x => x*x).Aggregate((x, y) => x+y);
        }

        return true;
    }
    
    public int[] PlusOne(int[] digits)
    {
        var n = new BigInteger();

        foreach (var i in digits)
        {
            n = BigInteger.Multiply(n, 10);
            n = BigInteger.Add(n, i);
        }

        n = BigInteger.Add(n, 1);
        var s = n.ToString();
        return s.Select(n => n - '0').ToArray();
    }
}