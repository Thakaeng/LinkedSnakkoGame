using UnityEngine;

public class PlayField : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject cam;

    private Vector2 cameraEvenPlayFieldOffset = new Vector2(-.5f, -.5f);

    private void Start()
    {
        for(int y = 0; y < MyGrid.PlayFieldSize; y++)
        {
            for(int x = 0; x < MyGrid.PlayFieldSize; x++)
            {
                var newTile = Instantiate(tilePrefab, MyGrid.grid[x, y], Quaternion.identity);
                newTile.transform.parent = transform;
                
                if(x == 0) newTile.GetComponent<Tile>().wallTile = Tile.WallTile.west;
                else if(x == MyGrid.PlayFieldSize) newTile.GetComponent<Tile>().wallTile = Tile.WallTile.east;
                
                if(y == 0) newTile.GetComponent<Tile>().wallTile = Tile.WallTile.south;
                else if(y == MyGrid.PlayFieldSize) newTile.GetComponent<Tile>().wallTile = Tile.WallTile.north;
            }
        }

        cam.transform.position = new Vector3(MyGrid.PlayFieldSize / 2, MyGrid.PlayFieldSize / 2, cam.transform.position.z);
        
        if(MyGrid.PlayFieldSize % 2 != 1)
        {
            cam.transform.Translate(cameraEvenPlayFieldOffset);
        }
    }
}
