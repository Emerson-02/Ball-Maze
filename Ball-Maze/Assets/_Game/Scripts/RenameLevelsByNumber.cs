using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RenameLevelsByNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text[] txtLevels;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < txtLevels.Length; i++)
        {
            txtLevels[i] = GetComponentsInChildren<TMP_Text>()[i];
            txtLevels[i].text = "Level " + (i + 1).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
