using UnityEngine;
using UnityEngine.Networking;

public class Combat : NetworkBehaviour
{
    Vector3 respawnPosition;

    public const int maxHealth = 100;
    [SyncVar] int health = maxHealth;
    public int Health
    {
        get
        {
            return health;
        }
    }
    
    void Awake()
    {
        respawnPosition = transform.position;
    }

    public void TakeDamage(int damage)
    {
        if (!isServer) return;

        if (health > damage)
        {
            health -= damage;
        }
        else
        {
            Respawn();
        }
    }

    void Respawn()
    {
        health = maxHealth;
        RpcRespawn();
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (!isLocalPlayer) return;

        transform.position = respawnPosition;
    }
}
