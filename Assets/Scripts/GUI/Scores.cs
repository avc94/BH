using UnityEngine;

public class Scores : MonoBehaviour
{
    private string scores = "scores string";
    private float posX = 50, posY = 50, scoresWidth, scoresHeight, buttonWidth = 100, buttonHeight = 20;
    GUIStyle style = new GUIStyle();

    void Awake()
    {
        scoresWidth = Screen.width - posX * 2;
        scoresHeight = Screen.height - (posY * 2 + buttonHeight);
    }

    void Update()
    {
        //to main menu
        if (Input.GetKey(KeyCode.Escape))
        {
            ToMainMenu();
        }
    }

    void OnGUI()
    {
        // show scores
        GUI.Label(new Rect(posX, posY, scoresWidth, scoresHeight), scores, style);

        // to main menu
        if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, posY + scoresHeight + 10, buttonWidth, buttonHeight), "BACK"))
        {
            ToMainMenu();
        }

    }

    void ToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
