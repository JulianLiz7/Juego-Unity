using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public string itemName = "Objeto";
    public AudioClip collectSound;
    public GameObject collectEffect;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entró al trigger: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador tocó el objeto recolectable!");

            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddItem(itemName);
            }

            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);

            if (collectEffect != null)
                Instantiate(collectEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
