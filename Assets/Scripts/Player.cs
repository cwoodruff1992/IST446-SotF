using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //==============
    // Player Stats
    //==============
    // Adjustable through menu
    // 5 = default values or middle everything
    public float max_speed = 5f;
    public int health = 5;
    public int damage = 5;
    public int range = 5;
    public int fire_rate = 5;
    public float jump_height = 100f;
    public bool right = true;
    public int number = 1;

    // Set the jump, shoot, and move buttons for each player
    public string myJump = "Jump (A) (P1)";
    public string myShoot = "Fire (B) (P1)";
    public string myHoriz = "Horizontal (LS) (P1)";

    // Check if the player is on the ground
    public LayerMask whatIsGround;
    public float groundRadius = 0.2f;
    private Transform groundCheck;
    private bool grounded = false;

    // Update while we're awake
    void Awake() {
        // Get the current instance of groundCheck to test for being grounded
        groundCheck = transform.Find("groundCheck");
    }

    // Update tied to the refresh rate
    void Update () {
        // If we press the default Jump buttons, and are grounded, apply our jump force
        if (Input.GetButtonDown(myJump) && grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump_height));

        }

        // If we press the fire button, prepare to fire
        bool shoot = Input.GetButtonDown(myShoot);

        // If we want to fire
        if (shoot) {
            // Get the weapon for this player
            Weapons weapon = GetComponent<Weapons>();
            // If the player does not have a weapon
            if (weapon != null) {
                // Player cannot attack
                weapon.Attack(true);
            }
        }
    }

    // Update on a designated clock tick
    void FixedUpdate () {

        if(this.health <= 0)
        {
            GetComponent<Rigidbody2D>().MovePosition(new Vector2(0,-100));
        }

        // Check if we're on the ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        // Get left-right movement input from controls
        float inputX = Input.GetAxis(myHoriz);

        // Move based on input and character speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(inputX * max_speed, GetComponent<Rigidbody2D>().velocity.y);

        // If we're not on the ground
        if (!grounded) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
        }

        // Get the player's current position
        Vector2 position = GetComponent<Rigidbody2D>().position;

        // Gets the player's current health
        Health playerHealth = this.GetComponent<Health>();

        // Check if falling off the screen down
        if (position.y <= Camera.main.gameObject.transform.position.y -5.58f) {
            playerHealth.hp = 0;
        }
        // Check if falling off the screen backwards
        if (position.x <= Camera.main.gameObject.transform.position.x - 11.53f) {
            playerHealth.hp = 0;
        }

        // Flip position of firing with direction
        if (inputX > 0)
            right = false;
        else if (inputX < 0)
            right = true;
    }
}
