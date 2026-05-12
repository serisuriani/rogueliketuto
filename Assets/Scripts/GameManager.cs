using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; } // Singleton instance
    public BoardManager BoardManager; // Reference to the BoardManager
    public PlayerController PlayerController; // Reference to the PlayerController

    public TurnManager TurnManager { get; private set; } // Reference to the TurnManager

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); // Ensure only one instance of GameManager exists
            return;
        }

        Instance = this; // Set the singleton instance
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnManager = new TurnManager(); // Initialize the TurnManager

        BoardManager.Init(); // Initialize the board
        PlayerController.Spawn(BoardManager, new Vector2Int(1, 1)); // Spawn the player at (1,1)
    }

}
