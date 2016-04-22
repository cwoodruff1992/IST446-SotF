using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    // Variable to store the number of the winner
    private int winner;

    // Variables to determine if certain players should be revived
    private bool p1alive = true;
    private bool p2alive = true;
    private bool p3alive = false;
    private bool p4alive = false;

    // Mark players as dead
    public void Died(int playerNum) {
        if (playerNum == 1)
            p1alive = false;

        if (playerNum == 2)
            p2alive = false;

        if (playerNum == 3)
            p3alive = false;

        if (playerNum == 4)
            p4alive = false;
    }

    // Mark players as reborn
    public void Reborn(int playerNum) {
        if (playerNum == 1)
            p1alive = true;

        if (playerNum == 2)
            p2alive = true;

        if (playerNum == 3)
            p3alive = true;

        if (playerNum == 4)
            p4alive = true;
    }

    // Return given player's state
    public bool GetStatus(int playerNum) {
        if (playerNum == 1)
            return p1alive;

        if (playerNum == 2)
            return p2alive;

        if (playerNum == 3)
            return p3alive;

        if (playerNum == 4)
            return p4alive;

        return false;
    }

    // Set who one the round
    public void SetWinner(int winnerNum) {
        winner = winnerNum;
    }
}
