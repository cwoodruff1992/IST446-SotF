using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

    // Variable for the particular damage of a weapon
    public int damage = 1;
    // Variable to determine if the shot should be identified as
    // and enemy's
    public bool isEnemyShot = true;
    // Lifetime of shot before destruction
    public int lifetime = 25;

	// Use this for initialization
	void Start () {
        // Destroy the shot after it has reached the end of its lifetime
        Destroy(gameObject, lifetime);
	}
}
