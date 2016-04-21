using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    private GameMaster GM;

    public Player player1;

	// Update is called once per frame
	void FixedUpdate () {
        GM = GameObject.Find("_GameMaster").GetComponent<GameMaster>();

        if (Mathf.Floor(Camera.main.gameObject.transform.position.x +5f) == Mathf.Floor(gameObject.transform.position.x))
        {
            if (GM.GetP1Alive() == false)
            {
                Instantiate(player1, new Vector3(gameObject.transform.position.x, 5.6f, 0), Quaternion.identity);
                GM.Reborn(1);
            }
        }
	}
}
