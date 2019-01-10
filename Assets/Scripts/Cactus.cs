using UnityEngine;

public class Cactus : MonoBehaviour
{
    int damage = 20;
    int durability = 3;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Cactus class triggered with " + collider.gameObject.name + " object");
        var hitCombat = collider.gameObject.GetComponent<Combat>();
        if (hitCombat != null)
        {
            hitCombat.TakeDamage(damage);
            if (--durability < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
