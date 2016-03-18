using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //==============
    // Player Stats
    //==============
    // Adjustable through menu
    // 5 = default values or middle everything
    // Use scale from 1 - 10 for each
    public float speed = 100f;
    public float max_speed = 5f;
    public int health = 5;
    public int damage = 5;
    public int range = 5;
    public int fire_rate = 5;
    public float jump_height = 100f;

    // Check if the player is on the ground
    public LayerMask whatIsGround;
    public float groundRadius = 0.2f;
    private Transform groundCheck;
    private bool grounded = false;

    // Update while we're awake
    void Awake()
    {
        // Get the current instance of groundCheck to test for being grounded
        groundCheck = transform.Find("groundCheck");
    }

    // Update tied to the refresh rate
    void Update ()
    {
        // If we press the default Jump buttons, and are grounded, apply our jump force
        if (Input.GetButtonDown("Jump") && grounded)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump_height));
    }

    // Update on a designated clock tick
    void FixedUpdate () {

        // Check if we're on the ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        // Get left-right movement input from controls
        float inputX = Input.GetAxis("Horizontal");

        // Move based on input and character speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(inputX * max_speed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
