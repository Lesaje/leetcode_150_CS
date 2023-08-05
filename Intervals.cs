namespace Leetcode150;

public static class Intervals
{
    
    //not quite working
    public static List<(int, int)> Insert(int[][] intervals, int[] newInterval)
    {
        var start = 0;
        var end = 0;

        //if (intervals.Length == 0) return new int[][] { newInterval };

        if (intervals[0][0] >= newInterval[1])
        {
            if (intervals[0][0] - newInterval[1] == 0)
            {
                start = newInterval[0];
                end = intervals[0][1];
            }
            else
            {
                start = newInterval[0];
                end = newInterval[1];
            }
        }
        
        
        for (var i = 0; i < intervals.Length; i++)
        {
            var interval = intervals[i];

            if (interval[1] >= newInterval[0] && start == 0)
            {
                start = interval[0];
                if (interval[1] >= newInterval[1]) end = interval[1];
            }
            if (interval[0] > newInterval[1] && end == 0) end = newInterval[1];
            if (interval[0] == newInterval[1] && end == 0) end = interval[1];
        }

        if (start == 0) end = newInterval[0];
        if (end == 0) end = newInterval[1];

        var ans = new List<(int, int)>();
        foreach (var interval in intervals)
        {
            if (interval[0] > end || interval[1] < start) ans.Add((interval[0], interval[1]));
            if (interval[0] == start) ans.Add((start, end));
        }

        var ansArr = new int[ans.Count][];
        var k = 0;
        foreach (var a in ans)
        {
            ansArr[k] = new[] { a.Item1, a.Item2 };
            k++;
        }
        
        return ans;

    }
}