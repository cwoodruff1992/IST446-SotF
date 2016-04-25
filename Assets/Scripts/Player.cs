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

    // Keep player score
    public int score = 0;

    // Set the jump, shoot, and move buttons for each player
    public string myJump = "Jump (A) (P1)";
    public string myShoot = "Fire (B) (P1)";
    public string myHoriz = "Horizontal (LS) (P1)";

    // Check if the player is on the ground
    public LayerMask whatIsGround;
    public float groundRadius = 0.2f;
    private Transform groundCheck;
    private bool grounded = false;

    // Variable to interface with the game master
    private GameMaster GM;

    void Start() {
        // Connect to the game master
        GM = GameObject.Find("_GameMaster").GetComponent<GameMaster>();
    }

    // Update while we're awake
    void Awake() {
        // Get the current instance of groundCheck to test for being grounded
        groundCheck = transform.Find("groundCheck");
    }

    // Update tied to the refresh rate
    void Update () {
        // If we press the default Jump buttons, and are grounded, apply our jump force
        if (Input.GetButtonDown(myJump) && grounded && GM.allowInput)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump_height));

        // If we press the fire button, prepare to fire
        bool shoot = Input.GetButtonDown(myShoot);

        // If we want to fire
        if (shoot && GM.allowInput) {
            // Get the weapon for this player
            Weapons weapon = GetComponent<Weapons>();
            // If the player does not have a weapon
            if (weapon != null) {
                // Player cannot attack
                weapon.Attack(false);
            }
        }
    }

    // Update on a designated clock tick
    void FixedUpdate () {

        // Check if we're on the ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        // Get left-right movement input from controls
        float inputX = Input.GetAxis(myHoriz);

        // Check if we're allowed to move
        if (GM.allowInput) {
            // Move based on input and character speed
            GetComponent<Rigidbody2D>().velocity = new Vector2(inputX * max_speed, GetComponent<Rigidbody2D>().velocity.y);

            // If we're not on the ground
            if (!grounded) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
            }
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
