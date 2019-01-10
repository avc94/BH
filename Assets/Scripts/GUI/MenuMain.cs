using UnityEngine;
using UnityEngine.Networking;

public class MenuMain : MonoBehaviour
{
    void OnGUI()
    {
        float xButtonSize = 120;
        float yButtonSize = 20;
        float replacement = 0;
        
        /*
        // singleplayer
        if (GUI.Button(new Rect(Screen.width / 2 - xButtonSize / 2, Screen.height / 2 - yButtonSize / 2, xButtonSize, yButtonSize), "SINGLEPLAYER"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1Singleplayer");
        }
        */

        // multiplayer
        replacement += yButtonSize + 10;
        if (GUI.Button(new Rect((Screen.width / 2 - xButtonSize / 2), (Screen.height / 2 - yButtonSize / 2) + replacement, xButtonSize, yButtonSize), "MULTIPLAYER"))
        {
            var manager = GameObject.Find("LobbyManager");
            if (manager != null)
            {
                var lobby = manager.GetComponent<NetworkLobbyGUI>();
                if (lobby != null)
                {
                    lobby.showGUI = true;
                }
            }
            
            UnityEngine.SceneManagement.SceneManager.LoadScene("MultiplayerMenu");
        }

        // about        
        replacement += yButtonSize + 10;
        if (GUI.Button(new Rect((Screen.width / 2 - xButtonSize / 2), (Screen.height / 2 - yButtonSize / 2) + replacement, xButtonSize, yButtonSize), "ABOUT"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("About");
        }

        // exit
        replacement += yButtonSize + 10;
        if (GUI.Button(new Rect((Screen.width / 2 - xButtonSize / 2), (Screen.height / 2 - yButtonSize / 2) + replacement, xButtonSize, yButtonSize), "EXIT"))
        {
            Application.Quit();
        }
    }
}
