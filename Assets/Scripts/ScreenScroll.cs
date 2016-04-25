using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class ScreenScroll : MonoBehaviour {

    // Variable to store how fast the stage should scroll
    public float speed;
    // Variable to determine where the end of the level is
    public float endOfLine;
    // Variable to determine where we start from
    private Vector3 startPosition;
    private GameMaster GM; 
    // The time at which the map began scrolling.
    private static float timeOffset = 0;
    // Time at which the end of the map was hit
    private static float gameover = -1;
    // Time to wait after hitting the end of a level before triggering a Draw
    private static float GAME_OVER_DELAY = 3;

    // At start up, do this
    void Start() {
        
        // Set our start position
        startPosition = transform.position;
        GM = GameObject.Find("_GameMaster").GetComponent<GameMaster>();
    }

    // When this scene is loaded
    void Awake()
    {
        timeOffset = Time.time;
    }

	// Update is called once per frame
	void Update () {
        // If the camera is before the stopping point
        if (timeOffset != -1 && Camera.main.gameObject.transform.position.x < endOfLine)
        {
            // Sets the gameover timer to "off"
            gameover = -1;
            // then scroll the camera according to the given speed
            transform.position = startPosition + new Vector3(1, 0, 0) * ((Time.time - timeOffset) * speed);
        }
        else if(gameover == -1)
        {
            gameover = Time.time;
        }
        else if(Time.time >= gameover + GAME_OVER_DELAY)
        {
            // Tell the game master there is no winner
            GM.SetWinner(-1);

            SceneManager.LoadScene("Winner");
        }
    }
}
