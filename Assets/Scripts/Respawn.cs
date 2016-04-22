using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Respawn : MonoBehaviour {

    // Variable to interface with the game master
    private GameMaster GM;
    // Variable to store the concept of player 1
    public Player player1 = null;
    public Player player2 = null;
    public Player player3 = null;
    public Player player4 = null;

    // Dictionary to relate numbers to player states
    Dictionary<int, Player> players = new Dictionary<int, Player>();

    // At startup, do this
    void Start() {
        // Connect to the game master
        GM = GameObject.Find("_GameMaster").GetComponent<GameMaster>();

        // Store the player connection in the dictionary
        players.Add(1, player1);
        players.Add(2, player2);
        players.Add(3, null);
        players.Add(4, null);
    }

	// Update is called once per frame
	void FixedUpdate () {
        // If the camera has passed the respawner
        if (Mathf.Floor(Camera.main.gameObject.transform.position.x +5f) == Mathf.Floor(gameObject.transform.position.x)) {
            // For each player,
            for(int i = 1; i <=4; i++) {
                // If they're not alive,
                if (GM.GetStatus(i) == false) {
                    // Resurect the player to the screen
                    Instantiate(players[i], new Vector3(gameObject.transform.position.x, 5.6f, 0), Quaternion.identity);
                    // Inform the GM of the player's resurection
                    GM.Reborn(i);
                }
            }
        }
	}
}
