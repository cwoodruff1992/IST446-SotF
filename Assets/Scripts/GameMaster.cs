using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    private bool p1alive = true;
    //private bool p2alive = true;
    //private bool p3alive = true;
    //private bool p4alive = true;

    public void Died(int playerNum) {
        if (playerNum == 1)
            p1alive = false;

        // Fill in rest of player if cases
    }

    public void Reborn(int playerNum) {
        if (playerNum == 1)
            p1alive = true;
    }

    public bool GetP1Alive() {
        return p1alive;
    }
}
