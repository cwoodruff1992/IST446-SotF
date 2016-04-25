using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    // Variable to store the number of the winner
    private int winner;
    private int raceWinner;
    private int winningScore = 0;

    // Variable to store the concept of player 1
    public Player player1 = null;
    public Player player2 = null;
    public Player player3 = null;
    public Player player4 = null;

    // Variables to store countdown sprites
    public Sprite cd1 = null;
    public Sprite cd2 = null;
    public Sprite cd3 = null;
    public Sprite cd4 = null;

    // Variables to store victory sprites
    public Sprite p1 = null;
    public Sprite p2 = null;
    public Sprite p3 = null;
    public Sprite p4 = null;

    // Tell screen to begin scrolling
    public bool startScroll = false;

    // Let input through
    public bool allowInput = false;

    // Let buttons be drawn on screen
    public bool allowButtons = false;

    // Button size
    const int buttonWidth = 120;
    const int buttonHeight = 60;

    // Variables to determine if certain players should be revived
    private bool p1alive = true;
    private bool p2alive = true;
    private bool p3alive = true;
    private bool p4alive = true;

    // Dictionary to relate numbers to player states
    Dictionary<int, Player> players = new Dictionary<int, Player>();
    Dictionary<int, Sprite> winners = new Dictionary<int, Sprite>();

    void Start() {
        // Store the player connection in the dictionary
        players.Add(1, player1);
        players.Add(2, player2);
        players.Add(3, player3);
        players.Add(4, player4);

        // Store the player sprites for winning
        winners.Add(1, p1);
        winners.Add(2, p2);
        winners.Add(3, p3);
        winners.Add(4, p4);

        StartCoroutine(getReady());
    }

    // Draw the GUI
    void OnGUI() {
        if (allowButtons) {
            Rect startRect = new Rect(Screen.width / 2 - (buttonWidth / 2), (9 * Screen.height / 10) - (buttonHeight / 2), buttonWidth, buttonHeight);

            if (GUI.Button(startRect, "Play Again?")) {
                SceneManager.LoadScene("Level 1");
            }
        }
    }

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

    // Award a player points
    public void AllotScore(int playerNum, int score) {
        players[playerNum].score += score;
    }

    // Race winner used for tie breaking
    public void RaceWinner(int playerNum) {
        raceWinner = playerNum;
    }

    // Set who one the round
    public void DetermineWinner() {
        for (int i = 1; i < 5; i++) {
            if (players[i].score > winningScore) {
                winningScore = players[i].score;
                winner = i;
            }  
        }

        //GetComponent<SpriteRenderer>().transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -1);
        GetComponent<SpriteRenderer>().sprite = winners[winner];
        allowInput = false;
        allowButtons = true;
    }

    // Countdown start timer
    IEnumerator getReady() {
        GetComponent<SpriteRenderer>().sprite = cd1;
        yield return new WaitForSeconds(1.5f);

        GetComponent<SpriteRenderer>().sprite = cd2;
        yield return new WaitForSeconds(1.5f);

        GetComponent<SpriteRenderer>().sprite = cd3;
        yield return new WaitForSeconds(1.5f);

        GetComponent<SpriteRenderer>().sprite = cd4;
        yield return new WaitForSeconds(1.5f);

        GetComponent<SpriteRenderer>().sprite = null;

        allowInput = true;
        startScroll = true;
    }
}
