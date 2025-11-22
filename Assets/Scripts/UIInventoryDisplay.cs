using UnityEngine;
using TMPro; // Usa esto si usas TextMeshPro

public class UIInventoryDisplay : MonoBehaviour
{
    public TMP_Text counterText; // Asigna un objeto de texto en la escena

    public void UpdateUI(int current, int total)
    {
        counterText.text = "💎 " + current + " / " + total;
    }
}
