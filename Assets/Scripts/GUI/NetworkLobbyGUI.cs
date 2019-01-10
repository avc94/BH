using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

#if ENABLE_UNET

[RequireComponent(typeof(NetworkManager))]
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public class NetworkLobbyGUI : MonoBehaviour
{
    public NetworkManager manager;
    [SerializeField] public bool showGUI = true;
    [SerializeField] public int offsetX;
    [SerializeField] public int offsetY;

    // Runtime variable
    //bool showServer = false; // never used?

    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    void Update()
    {
        if (!showGUI) return;

        if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                manager.StartServer();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                manager.StartHost();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                manager.StartClient();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToMainMenu();
            }
        }
        if (NetworkServer.active || NetworkClient.active)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                manager.StopHost();
            }
        }
    }

    void OnGUI()
    {
        if (!showGUI) return;

        int xpos = 10 + offsetX;
        int ypos = 40 + offsetY;
        int spacing = 24;

        if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
        {
            if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Start Host (H)"))
            {
                manager.StartHost();
            }
            ypos += spacing;

            if (GUI.Button(new Rect(xpos, ypos, 100, 20), "Connect (C)"))
            {
                manager.StartClient();
            }
            manager.networkAddress = GUI.TextField(new Rect(xpos + 100, ypos, 100, 20), manager.networkAddress);
            ypos += spacing;

            if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Start Server Only (S)"))
            {
                manager.StartServer();
            }
            ypos += spacing;

            if (GUI.Button(new Rect(xpos, ypos, 200, 20), "To Main Menu (Esc)"))
            {
                ToMainMenu();
            }
            ypos += spacing;
        }
        else
        {
            if (NetworkServer.active)
            {
                GUI.Label(new Rect(xpos, ypos, 300, 20), "Server: port=" + manager.networkPort);
                ypos += spacing;
            }
            if (NetworkClient.active)
            {
                GUI.Label(new Rect(xpos, ypos, 300, 20), "Client: address=" + manager.networkAddress + " port=" + manager.networkPort);
                ypos += spacing;
            }
        }

        if (NetworkClient.active && !ClientScene.ready)
        {
            if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Client Ready"))
            {
                ClientScene.Ready(manager.client.connection);

                if (ClientScene.localPlayers.Count == 0)
                {
                    ClientScene.AddPlayer(0);
                }
            }
            ypos += spacing;
        }

        if (NetworkServer.active || NetworkClient.active)
        {
            if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Stop (X)"))
            {
                manager.StopHost();
            }
            ypos += spacing;
        }
    }

    void ToMainMenu()
    {
        showGUI = false;
        SceneManager.LoadScene("MainMenu");
    }
}

#endif //ENABLE_UNET
