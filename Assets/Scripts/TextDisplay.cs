using UnityEngine;
using System.Collections;

public class TextDisplay : MonoBehaviour {

    public int p1health = 0;
    public int p2health = 0;
    public int p3health = 0;
    public int p4health = 0;

    public int p1score = 0;
    public int p2score = 0;
    public int p3score = 0;
    public int p4score = 0;

    void Start() {
        p1health = GameObject.Find("Player").GetComponent<Health>().hp;
        p2health = GameObject.Find("Player 1").GetComponent<Health>().hp;
        p3health = GameObject.Find("Player 2").GetComponent<Health>().hp;
        p4health = GameObject.Find("Player 3").GetComponent<Health>().hp;

        p1score = GameObject.Find("Player1").GetComponent<Player>().score;
        p2score = GameObject.Find("Player 1").GetComponent<Player>().score;
        p3score = GameObject.Find("Player 2").GetComponent<Player>().score;
        p4score = GameObject.Find("Player 3").GetComponent<Player>().score;
    }
	
}
