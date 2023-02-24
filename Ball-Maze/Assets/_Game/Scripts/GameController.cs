using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float currentTime, finalTime;
    private Transform playerStartPosition;

    
    public void GameOver(GameObject player)
    {
        player.transform.position = playerStartPosition.position;
    }
}
