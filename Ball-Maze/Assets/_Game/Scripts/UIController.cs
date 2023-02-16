using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text txtCurrentTime, txtFinalTime;
    private GameController gameController;
    public GameObject panelGame, panelFinishGame, panelPause;
    public bool  winGame;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        panelFinishGame.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        winGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!winGame)
        {
            gameController.currentTime += Time.deltaTime;
            UpdateText();
        }
        
    }

    public void WinGame()
    {
        txtFinalTime.text = gameController.finalTime.ToString("00:00");
        panelFinishGame.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
    }

    void UpdateText()
    {
        float seconds = (gameController.currentTime % 60);
        float minutes = ((int)(gameController.currentTime / 60) % 60);

        txtCurrentTime.text = minutes.ToString("00") + ":" + seconds.ToString("00");    
    }

    public void ButtonRestartGame()
    {
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        tempPlayer.GetComponent<PlayerMovement>().isMovement = true;
        gameController.GameOver(tempPlayer.gameObject);
        panelFinishGame.gameObject.SetActive(false);
        gameController.currentTime = 0f;
        winGame = false;
    }
}
