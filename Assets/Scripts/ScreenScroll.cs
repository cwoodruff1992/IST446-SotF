using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScreenScroll : MonoBehaviour {

    // Variable to store how fast the stage should scroll
    public float speed;
    // Variable to determine where the end of the level is
    public float endOfLine;

    // Variable to determine where we start from
    private Vector3 startPosition;
    // Variable to interface with game master
    private GameMaster GM;

    // At start up, do this
    void Start() {
        // Hook to the game master for communication
        GM = GameObject.Find("_GameMaster").GetComponent<GameMaster>();

        // Set our start position
        startPosition = transform.position;
    }

	// Update is called once per frame
	void Update () {
        // Start scrolling if the countdown has finished
        if (GM.startScroll) {
            // If the camera is before the stopping point
            if (Camera.main.gameObject.transform.position.x < (endOfLine - 10.6f))
                // then scroll the camera according to the given speed
                transform.position = startPosition + new Vector3(1, 0, 0) * ((Time.timeSinceLevelLoad - 6) * speed);
        }
    }
}
