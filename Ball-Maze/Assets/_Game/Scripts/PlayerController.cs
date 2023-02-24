using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider target) 
    {
        if(target.gameObject.CompareTag("Lose"))
        {
            GameController tempGameController = FindObjectOfType<GameController>();
            tempGameController.GameOver(this.gameObject);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
        else if(target.gameObject.CompareTag("Win"))
        {
            this.gameObject.GetComponent<PlayerMovement>().isMovement = false;
            GameController tempGameController = FindObjectOfType<GameController>();
            tempGameController.finalTime = tempGameController.currentTime;
            Debug.Log(tempGameController.finalTime);
            UIController tempUIController = FindObjectOfType<UIController>();
            tempUIController.WinGame();
        }
        
    }
}
