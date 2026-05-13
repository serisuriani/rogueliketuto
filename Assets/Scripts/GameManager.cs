using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; } // Singleton instance
    public BoardManager BoardManager; // Reference to the BoardManager
    public PlayerController PlayerController; // Reference to the PlayerController

    public TurnManager TurnManager { get; private set; } // Reference to the TurnManager
    public UIDocument UIDoc; // Reference to the UI Document for displaying game information

    private Label m_FoodLabel; // UI label to display food amount
    private int m_FoodAmount = 100; // Example of a game state variable

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); // Ensure only one instance of GameManager exists
            return;
        }

        Instance = this; // Set the singleton instance
    }

    public void ChangeFood(int amount)
    {
        m_FoodAmount += amount;
        m_FoodLabel.text = "Food: " + m_FoodAmount; // Update the food label text
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnManager = new TurnManager(); // Initialize the TurnManager
        TurnManager.OnTick += OnTurnHappen; // Subscribe to the turn tick event

        BoardManager.Init(); // Initialize the board
        PlayerController.Spawn(BoardManager, new Vector2Int(1, 1)); // Spawn the player at (1,1)

        m_FoodLabel = UIDoc.rootVisualElement.Q<Label>("FoodLabel"); // Find the food label in the UI
        m_FoodLabel.text = "Food: " + m_FoodAmount; // Initialize the food label text
    }

    void OnTurnHappen()
    {
        m_FoodAmount -= 1; // Example of turn-based logic: decrease food amount each turn
        Debug.Log("Food Amount: " + m_FoodAmount);
        m_FoodLabel.text = "Food: " + m_FoodAmount; // Update the food label text
        ChangeFood(-1); // Decrease food by 1 each turn
    }
}
