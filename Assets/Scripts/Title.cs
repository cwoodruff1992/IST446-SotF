using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {


    // Draw the GUI
    void OnGUI() {
        const int buttonWidth = 120;
        const int buttonHeight = 60;

        Rect startRect = new Rect(Screen.width / 3 - (buttonWidth / 2), (9 * Screen.height / 10) - (buttonHeight / 2), buttonWidth, buttonHeight);
        Rect controlsRect = new Rect(Screen.width / 3 - (buttonWidth / 2) + (buttonWidth * 2), ((9 * Screen.height / 10) - (buttonHeight / 2)), buttonWidth, buttonHeight);
        Rect creditsRect = new Rect(Screen.width / 3 - (buttonWidth / 2) + (buttonWidth * 4), ((9 * Screen.height / 10) - (buttonHeight / 2)), buttonWidth, buttonHeight);

        if (GUI.Button(startRect, "Play")) {
            SceneManager.LoadScene("Level 1");
        }

        if (GUI.Button(controlsRect, "Controls")) {
            SceneManager.LoadScene("Controls");
        }

        if (GUI.Button(creditsRect, "Credits")) {
            SceneManager.LoadScene("Credits");
        }
    }
}
