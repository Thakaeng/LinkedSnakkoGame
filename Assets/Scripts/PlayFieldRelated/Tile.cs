using UnityEngine;

public class Tile : MonoBehaviour
{
    public WallTile wallTile = WallTile.no;
    public Vector2 position;
    public enum WallTile
    {
        north, east, south, west, no
    }
}
