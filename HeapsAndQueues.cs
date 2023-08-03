namespace Leetcode150;

public static class Heap
{

    public static int LastStoneWeight(int[] stones)
    {
        if (stones.Length == 1) return stones[0];
        
        var q = new PriorityQueue<int, int>();

        foreach (var i in stones)
        {
            q.Enqueue(i, -i);
        }

        while (q.Count != 0)
        {
            if (q.Count == 1) return q.Dequeue();
            
            var a = q.Dequeue();
            var b = q.Dequeue();

            if (Math.Abs(a - b) != 0)
            {
                q.Enqueue(Math.Abs(a - b), -Math.Abs(a - b));
            }
        }
        
        return 0;
    }
    
    public static int[][] KClosest(int[][] points, int k)
    {
        var answer = new int[k][];
        
        for (var i = 0; i < k; i++)
        {
            answer[i] = new int[2];
        }
        
        var q = new PriorityQueue<int[], double>();
        
        foreach (var point in points)
        {
            q.Enqueue(point, Distance(point[0], point[1]));
        }
        
        for (var i=0; i<k; i++)
        {
            var point = q.Dequeue();
            answer[i] = point;
        }
        
        return answer;
        
        double Distance(int x, int y)
        {
            return Math.Sqrt(x * x + y * y);
        }
    }

}