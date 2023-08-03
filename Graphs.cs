namespace Leetcode150;

public class Graphs
{
    private int Dfs(char[][] grid, int i, int j)
    {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == '0')
        {
            return 0;
        }

        grid[i][j] = '0';
        Dfs(grid, i + 1, j);
        Dfs(grid, i - 1, j);
        Dfs(grid, i , j + 1);
        Dfs(grid, i, j - 1);
        return 1;
    }
    
    public int NumIslands(char[][] grid)
    {
        if (grid == null || grid.Length == 0) return 0;

        var numIslands = 0;

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid.Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    numIslands += Dfs(grid, i, j);
                }
            }
        }

        return numIslands;
    }
}