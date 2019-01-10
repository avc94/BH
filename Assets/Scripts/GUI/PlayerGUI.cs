using UnityEngine;
using UnityEngine.Networking;

public class PlayerGUI : NetworkBehaviour
{
    Combat combat;
    PlayerInventory inventory;

    void Awake()
    {
        combat = GetComponent<Combat>();
        inventory = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        // suicide
        if (Input.GetKey(KeyCode.K))
        {
            CmdSuicide();
        }
    }

    void OnGUI()
    {
        if (!isLocalPlayer) return;

        if (inventory.BadgesOnLevelRemaining > 0)
        {
            float infoBoxWidth = 150;
            float infoBoxHeight = 68;
            float buttonWidth = 120;
            float buttonHeight = 20;
            float replacement = infoBoxHeight + 10;

            GUI.Box(new Rect(0, Screen.height - infoBoxHeight, infoBoxWidth, infoBoxHeight),
                "\nBadges collected: " + inventory.Badges +
                "\nBadges remaining: " + inventory.BadgesOnLevelRemaining +
                "\nHealth: " + combat.Health);

            // suicide
            replacement += buttonHeight + 10 + 10;
            if (GUI.Button(new Rect(10, replacement, buttonWidth, buttonHeight), "SUICIDE (K)"))
            {
                CmdSuicide();
            }
        }
        else // show match results
        {
            float infoBoxWidth = 300;
            float infoBoxHeight = 150;

            int badgesCollectedByEnemy = inventory.BadgesOnLevel - inventory.Badges;

            GUI.Box(new Rect(Screen.width / 2 - infoBoxWidth / 2, Screen.height / 2 - infoBoxHeight / 2, infoBoxWidth, infoBoxHeight),
                (inventory.Badges > badgesCollectedByEnemy ? "Victory!" : inventory.Badges == badgesCollectedByEnemy ? "Draw!" : "This time you loose...") +
                "\nBadges collected by you:   " + inventory.Badges +
                "\nBadges collected by enemy: " + badgesCollectedByEnemy);
        }
    }

    [Command]
    void CmdSuicide()
    {
        combat.TakeDamage(Combat.maxHealth);
    }
}
