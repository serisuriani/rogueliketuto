using UnityEngine;
using UnityEngine.Tilemaps;

public class WallObject : CellObject
{
    public Tile ObstacleTile;

    public override void Init(Vector2Int cell)
    {
        base.Init(cell);
        GameManager.Instance.BoardManager.SetCellTile(cell, ObstacleTile);
        // Additional initialization for the wall object if needed
    }

    public override bool PlayerWantsToEnter()
    {
        return false; // Walls are not considered equal to any other object, including other walls
    }
    
}
