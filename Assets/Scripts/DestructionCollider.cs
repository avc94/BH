using UnityEngine;

public class DestructionCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("DestructionCollider class triggered with " + collider.gameObject.name + " object");

        var combat = collider.gameObject.GetComponent<Combat>();
        if (combat != null)
        {
            combat.TakeDamage(Combat.maxHealth);
        }
        else
        {
            Debug.Log("Destroying " + collider.gameObject.name + " object");
            Destroy(collider.gameObject);
        }
    }
}
