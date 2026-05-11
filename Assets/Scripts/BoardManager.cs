using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    private Tilemap m_Tilemap;

    public int Width;
    public int Height;
    public Tile[] GroundTiles; // to store ground tile sprites
    public Tile[] WallTiles; // to store wall/border tile sprites
// Start is called before the first frame update
    void Start()
    {
        m_Tilemap = GetComponentInChildren<Tilemap>();

        for (int y=0; y<Height; ++y)
        {
            for (int x=0; x<Width; ++x)
            {
                Tile tile;
                
                if (x==0 || y==0 || x==Width-1 || y==Height-1)
                {
                    tile = WallTiles[Random.Range(0, WallTiles.Length)]; // Set border tiles
                }
                else
                {
                    tile = GroundTiles[Random.Range(0, GroundTiles.Length)];  // Set random ground tiles for inner area
                }
                m_Tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }

}
