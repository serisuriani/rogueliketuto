using UnityEngine;

public class FoodObject : CellObject
{
    public int AmountGranted = 10; // Amount of food granted to the player when collected
    public override void PlayerEntered()
    {
        Destroy(gameObject); // Destroy the food object when the player enters the cell

        //increase food
        GameManager.Instance.ChangeFood(AmountGranted);
        Debug.Log("Food increased");

    }


}
