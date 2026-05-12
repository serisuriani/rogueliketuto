using UnityEngine;

public class TurnManager
{
    public event System.Action OnTick; // Event to notify when a turn has advanced
    private int m_TurnCount;

    public TurnManager()
    {
        m_TurnCount = 1;
    }

    public void Tick()
    {
        m_TurnCount +=1;
        Debug.Log("Current Turn Count: " + m_TurnCount);
        OnTick?.Invoke(); // Notify subscribers that a turn has advanced
    }
}
