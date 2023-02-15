using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float currentTime, finalTime;
    public Transform playerStartPosition;
    public bool gameover;
    
    public void GameOver(GameObject player)
    {
        if(gameover)
        {
            player.transform.position = playerStartPosition.position;
        }
    }
}
