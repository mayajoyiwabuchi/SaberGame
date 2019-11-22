using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject secondPlayer;
    public GameObject blobwin;
    public GameObject iseckewin;
    public Vector3 movespdleft;
    public Vector3 movespdright;
    public Vector3 jumpspd;
    public bool canJump;
    public bool collidingPlayer;
    private GameManager _gameManager;
    private Rigidbody2D _rigidbody2D;
    private Rigidbody2D _rigidbody2D1;
    private Rigidbody2D _rigidbody2D2;
    private Rigidbody2D _rigidbody2D3;
    public int facing;
    public int player;
    public int force;
    public KeyCode upkey;
    public KeyCode leftkey;
    public KeyCode rightkey;
    public KeyCode swingkey;
    // Start is called before the first frame update
    void Start()
    {
        facing = 1;
        _rigidbody2D3 = secondPlayer.GetComponent<Rigidbody2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gameManager = gameManager.GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        //depending on what WASD key u press
        if (Input.GetKey(leftkey))
        {
            facing = -1;
            //makes the player face either left or right
            
            //adds force to their rigidbody, makes them move left or right
            _rigidbody2D.AddForce(movespdleft);
        }
        if (Input.GetKey(rightkey))
        {
            facing = 1;
            _rigidbody2D.AddForce(movespdright);
        }
        if (Input.GetKeyDown(upkey) && canJump)
        {
            //makes the player jump, adds force to y of rigidbody
            _rigidbody2D.AddForce(jumpspd);
            //this bool says that the player is not on the ground
            //to set it to true, it must detect a collision with the platform
            //no double jumping!!
            canJump = false;
        }
        if (collidingPlayer)
        {
            Debug.Log("can press swing key");
            //checks to see if we are colliding with a player
            if (Input.GetKeyDown(swingkey))
            {
                switch (facing)
                {
                    case 1:
                        _rigidbody2D3.AddForce(transform.right * force);
                        break;
                    case -1:
                        _rigidbody2D3.AddForce(-transform.right * force);
                        break;
                }
                Debug.Log("hit player");
            }
        }
        if (transform.position.y < -8)
        {
            
            Debug.Log("playing megalovania");
            Debug.Log("player "+player+" dead");
            switch (player)
            {
                case 1:
                    iseckewin.SetActive(true);
                    Debug.Log("Player 2 wins");
                    break;
                case 2:
                    blobwin.SetActive(true);
                    Debug.Log("Player 1 wins");
                    break;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Player"))
            //if the object collided with is a player
        {
            Debug.Log("colliding");
            //sets boolean to true
            collidingPlayer = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("not colliding");
            //if the player is no longer colliding with the object
            //set boolean to false
            collidingPlayer = false;
        } 
    }
}