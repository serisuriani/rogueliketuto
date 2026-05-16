using UnityEngine;

public class CellObject : MonoBehaviour
{
    protected Vector2Int m_Cell;

    public virtual void Init(Vector2Int cell)
    {
        m_Cell = cell;
    }

    public virtual bool PlayerWantsToEnter()
    {
        return true; // By default, allow the player to enter the cell
    }
    //called when the player enter the cell in which that object is located
    public virtual void PlayerEntered()
    {
        
    }
    
}
