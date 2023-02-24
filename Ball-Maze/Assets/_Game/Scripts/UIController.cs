using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text txtCurrentTime, txtFinalTime;
    private GameController gameController;
    [SerializeField] private GameObject panelGame, panelFinishGame, panelPause;
    private bool winGame;
    private int nextSceneLoad;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        panelFinishGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        winGame = false;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
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

        if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
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

    public void ButtonPauseGame()
    {
        panelPause.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ButtonResumeGame()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ButtonBackMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ButtonNextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 24)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextSceneLoad);
        }

        
    }
}
