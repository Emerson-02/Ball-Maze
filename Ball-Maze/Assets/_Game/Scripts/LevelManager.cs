using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public UnityEngine.UI.Button[] btnLevels;
    public GameObject[] imgLevels;
    public Sprite imgLock, imgUnlock;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < btnLevels.Length; i++)
        {
            int index = i;
            btnLevels[i] = GetComponentsInChildren<UnityEngine.UI.Button>()[i];
            btnLevels[i].onClick.AddListener(() => LoadLevelByIndex((i - i) + (index + 1)));
        }

        imgLevels = GameObject.FindGameObjectsWithTag("ImageLock");
    }

    void Start() 
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for (int i = 0; i < btnLevels.Length; i++)
        {
            if(i + 1 > levelAt)
            {
                btnLevels[i].interactable = false;
                imgLevels[i].GetComponent<UnityEngine.UI.Image>().sprite = imgLock;
            }
            else
            {
                imgLevels[i].GetComponent<UnityEngine.UI.Image>().sprite = imgUnlock;
            }
        }
    }

    void LoadLevelByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
