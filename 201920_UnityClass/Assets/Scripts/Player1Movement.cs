using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public GameObject gameManager;
    
    public Vector3 movespdleft;
    public Vector3 movespdright;
    public Vector3 jumpspd;

    public bool canJump;

    public bool swordSwung;

    public bool collidingPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //depending on what WASD key u press
        if (Input.GetKeyDown(KeyCode.A))
        {
            //makes the player face either left or right
            transform.localScale = new Vector3(-1, 0);
            //adds force to their rigidbody, makes them move left or right
            GetComponent<Rigidbody2D>().AddForce(movespdleft);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 0);
            GetComponent<Rigidbody2D>().AddForce(movespdright);
        }
        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            //makes the player jump, adds force to y of rigidbody
            GetComponent<Rigidbody2D>().AddForce(jumpspd);
            //this bool says that the player is not on the ground
            //to set it to true, it must detect a collision with the platform
            //no double jumping!!
            canJump = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //checks to see if we are colliding with a player
            if (collidingPlayer)
            {
                
            }
        }

        if (transform.position.y < -8)
        {
            gameManager.GetComponent<GameManager>().gameWinP2 = true;
        }
    }


    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            canJump = true;
        }

        if (collision.gameObject.tag=="Player")
            //if the object collided with is a player
        {
            //sets boolean to true
            collidingPlayer = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag=="Player")
        {
            //if the player is no longer colliding with the object
            //set boolean to false
            collidingPlayer = false;
        } 
    }
}
