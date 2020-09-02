using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float horizontal;
    public float normSpeed; // the normal movement speed
    public float dashSpeed; // the speed for the dash
    private Rigidbody2D myRB;

    public GameObject groundCheck = null;
    public bool grounded;
    public float jumpHeight;
    private float jump;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>(); // gets the rigidbody component on the player
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    // calls on the movement function every other frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Jump");

        PlayerMove();
    }

    // this function contains the dash mechanic for the player
    // it is located between lines 55 and 59
    // the rest of the code is for basic moving and jumping
    void PlayerMove()
    {
        float currentYVal = myRB.velocity.y; // shortcut for the y value of the velocity for the player

        // allows the player to move left and right
        if (horizontal == 1 || horizontal == -1)
        {
            myRB.velocity = new Vector2(horizontal * normSpeed, currentYVal);
        }
        else
        {
            myRB.velocity = new Vector2(0, currentYVal);
        }

        // lets the player dash as they are moving
        if (Input.GetKey(KeyCode.G))
        {
            myRB.velocity = new Vector2(horizontal * dashSpeed, currentYVal);
        }

        if (Physics2D.Linecast(transform.position, groundCheck.transform.position))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (grounded == true)
        {
            myRB.AddForce(new Vector2(0, jump * jumpHeight));
        }
    }
}
