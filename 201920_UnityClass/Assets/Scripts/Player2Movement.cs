using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    
    public GameObject gameManager;
    public Vector3 movespdleft;
    public Vector3 movespdright;
    public Vector3 jumpspd;

    public bool canJump;

    

    public bool swordSwung;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(movespdleft);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(movespdright);
        }
        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpspd);
            canJump = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            swordSwung = true;
        }
        if (transform.position.y < -8)
        {
            gameManager.GetComponent<GameManager>().gameWinP1 = true;
        }
    }


    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            canJump = true;
        } 
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag=="Player" && swordSwung)
        {
            swordSwung = false;
        }
    }
}
