using UnityEngine;
using UnityEngine.Networking;

public class PlayerInventory : NetworkBehaviour
{
    [SyncVar] public int Badges = 0;
    public int BadgesOnLevel;
    public int BadgesOnLevelRemaining;

    PlayerInventory[] playerInventoryList;

    void Awake()
    {
        BadgesOnLevel = FindObjectsOfType<Badge>().Length;
        BadgesOnLevelRemaining = BadgesOnLevel;
    }

    void FixedUpdate()
    {
        if (playerInventoryList == null || playerInventoryList.Length < 2)
        {
            playerInventoryList = FindObjectsOfType<PlayerInventory>();
        }

        BadgesOnLevelRemaining = BadgesOnLevel - GetAllCollectedBadgesCount();
    }

    int GetAllCollectedBadgesCount()
    {
        int summary = 0;
        foreach (var inventory in playerInventoryList)
        {
            summary += inventory.Badges;
        }
        return summary;
    }

    public void AddBadges(int badges)
    {
        if (!isServer) return;

        if (badges > 0)
        {
            Debug.Log("Picked badge");
            this.Badges += badges;
        }
    }
}
