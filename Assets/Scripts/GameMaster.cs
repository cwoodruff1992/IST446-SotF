using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    private Player player1;
    //private Player player2;
    //private Player player3;
    //private Player player4;

    private bool p1alive = true;
    //private bool p2alive = true;
    //private bool p3alive = true;
    //private bool p4alive = true;

    // Use this for initialization
    void Start () {
	    
    }

    // Update is called once per frame
    void Update () {
        player1 = GameObject.Find("Player1").GetComponent<Player>();
        //player2 = GameObject.Find("Player2").GetComponent<Player>();
        //player3 = GameObject.Find("Player3").GetComponent<Player>();
        //player4 = GameObject.Find("Player4").GetComponent<Player>();

        if (player1 == null)
            p1alive = false;
        else
            p1alive = true;

        // Fill in rest of player if cases


    }

    public void Died(int playerNum)
    {
        if (playerNum == 1)
        {
            p1alive = false;
        }

        // Fill in rest of player if cases
    }

    public bool GetP1Alive()
    {
        return p1alive;
    }
}
