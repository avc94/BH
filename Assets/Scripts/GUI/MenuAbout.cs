using UnityEngine;

public class MenuAbout : MonoBehaviour
{
    string About = "Hello!" +
    "\nCollect all Gold Badges, and be careful with cactuses!:)" +
    "\nRemember, each badge make you closer to the victory," +
    "\nso don't let your opponent collect them!" +
    "\nYou'll see results after last badge is being picked." +
    "\nSee the hotkeys, somesimes they're useful. Also" +
    "\nyou can see more controls and change them in launcher." +
    "\n\nAuthor: Avchiyev A. O., 4 KN-A1, Vinnytsya, DonNU" +
    "\n2017";

    void Update()
    {
        //quit
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }

    void OnGUI()
    {
        float x = 360;
        float y = 160;
        float buttonWidth = 100;
        float buttonHeight = 20;

        GUI.skin.box.alignment = TextAnchor.MiddleCenter;
        GUI.Box(new Rect(Screen.width / 2 - x / 2, Screen.height / 2 - y / 2, x, y), About);

        if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, Screen.height / 2 + y / 2 + 10, buttonWidth, buttonHeight), "BACK"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}
