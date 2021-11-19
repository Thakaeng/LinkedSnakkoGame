using UnityEngine;

public static class MyGrid
{
    public const int PlayFieldSize = 9;
    public static Vector2[,] grid = new Vector2[PlayFieldSize, PlayFieldSize];
    public static Tile[,] tiles = new Tile[PlayFieldSize, PlayFieldSize];

    static MyGrid()
    {
        for(int y = 0; y < PlayFieldSize; y++)
        {
            for(int x = 0; x < PlayFieldSize; x++)
            {
                grid[x, y] = new Vector2(x, y);
            }
        }
    }
}
