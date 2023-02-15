using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider target) 
    {
        if(target.gameObject.CompareTag("Lose"))
        {
            GameController tempGameController = FindObjectOfType<GameController>();
            tempGameController.gameover = true;tempGameController.GameOver(this.gameObject);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
        else if(target.gameObject.CompareTag("Win"))
        {
            this.gameObject.GetComponent<PlayerMovement>().isMovement = false;
            GameController tempGameController = FindObjectOfType<GameController>();
            tempGameController.finalTime = tempGameController.currentTime;
            Debug.Log(tempGameController.finalTime);
        }
        
    }
}
