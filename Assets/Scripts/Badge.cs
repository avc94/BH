using UnityEngine;

public class Badge : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Badge class triggered with " + collider.gameObject.name + " object");
        var playerInventory = collider.gameObject.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.AddBadges(1);
            Destroy(gameObject);
        }
    }
}
