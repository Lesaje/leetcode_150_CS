namespace Leetcode150;

public static class AdvancedGraphs
{
    public static int ManhattanDistance((int, int) a, (int, int) b)
    {
        return Math.Abs(a.Item1 - b.Item1) + Math.Abs(a.Item2 - b.Item2);
    }

    record Edge(int From, int To);
    
    //not quite working
    public static int MinCostConnectPoints(int[][] points)
    {
        var connectedVertices = new Dictionary<int, int>();
        var edges = new PriorityQueue<Edge, int>();
        var answer = 0;

        connectedVertices.Add(0, 0);    //first vertex
        for (var i = 1; i < points.Length; i++)
        {
            edges.Enqueue(new Edge(0, i), ManhattanDistance((points[0][0], points[0][1]), (points[i][0], points[i][1])));
        }
        
        while (connectedVertices.Count != points.Length)
        {
            var distance = 0;
            var nextEdge = new Edge(0, 0);
            edges.TryDequeue(out nextEdge, out distance);
            answer += distance;
            connectedVertices.Add(nextEdge.To, nextEdge.To);
            for (var i = 0; i < points.Length; i++)
            {
                if (!connectedVertices.ContainsKey(i))
                {
                    edges.Enqueue(
                        new Edge(nextEdge.To, i), 
                        ManhattanDistance((points[nextEdge.To][0], points[nextEdge.To][1]), (points[i][0], points[i][1]))
                        );
                }
            }
        }

        return answer;
    }
}