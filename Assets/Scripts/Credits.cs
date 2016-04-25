using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    // Draw the GUI
    void OnGUI() {
        const int buttonWidth = 120;
        const int buttonHeight = 60;

        Rect startRect = new Rect(Screen.width / 2 - (buttonWidth / 2), (9 * Screen.height / 10) - (buttonHeight / 2), buttonWidth, buttonHeight);

        if (GUI.Button(startRect, "Back")) {
            SceneManager.LoadScene("Title");
        }
    }
}
