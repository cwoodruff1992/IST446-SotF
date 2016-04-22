using UnityEngine;
using System.Collections;

public class EndOfLevel : MonoBehaviour {

    private GameMaster GM;
    private Player winner;

    void Start() {
        GM = GameObject.Find("_GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 10f, 1 << LayerMask.NameToLayer("Players"));

        if(hit.collider != null) {
            winner = hit.collider.GetComponent<Player>();
            GM.SetWinner(winner.number);
        }
    }
}
