using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int collectedCount = 0;    // Objetos recogidos
    public int totalCollectibles = 10; // Total en el nivel (puedes cambiarlo)
    public UIInventoryDisplay uiDisplay;

    public void AddItem(string itemName)
    {
        collectedCount++;
        Debug.Log("Has recolectado: " + itemName + " | Total: " + collectedCount);

        if (uiDisplay != null)
        {
            uiDisplay.UpdateUI(collectedCount, totalCollectibles);
        }
    }
}
