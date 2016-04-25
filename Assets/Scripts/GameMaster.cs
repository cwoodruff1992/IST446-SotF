using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    // Variable to store the number of the winner
    private static int winner;

    // Variable to determine whether gameplay began
    private static bool playing = false;

    // Variables to determine if certain players should be revived
    private static bool p1alive = true;
    private static bool p2alive = true;
    private static bool p3alive = true;
    private static bool p4alive = true;

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

    // Set who won the round
    public void SetWinner(int winnerNum) {
        winner = winnerNum;
        playing = false;
    }

    // Get who Won the round
    public string GetWinner()
    {
        switch (winner)
        {
            case 1:
                return "Chicken";
                break;
            case 2:
                return "Pig";
                break;
            case 3:
                return "Deer";
                break;
            case 4:
                return "Panda";
                break;
            default:
                return "Draw! There was no winner!";
                break;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
