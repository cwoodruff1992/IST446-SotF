using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    private GameMaster GM;

    public Player player1;

	// Update is called once per frame
	void FixedUpdate () {
        GM = GameObject.Find("_GameMaster").GetComponent<GameMaster>();

        if (Camera.main.gameObject.transform.position.x == gameObject.transform.position.x)
        {
            if (GM.GetP1Alive())
                Instantiate(player1, new Vector3(0, 5.6f, 0), Quaternion.identity);
        }
	}
}
