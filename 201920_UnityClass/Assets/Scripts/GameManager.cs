using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameWinP1;

    public bool gameWinP2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameWinP1)
        {
            Debug.Log("Game Over. P1 Wins.");
        }

        if (gameWinP2)
        {
            Debug.Log("Game Over. P2 Wins.");
        }
    }
}
