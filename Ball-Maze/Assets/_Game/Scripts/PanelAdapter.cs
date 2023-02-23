using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAdapter : MonoBehaviour
{
    [SerializeField] private RectTransform[] panels;

    // Start is called before the first frame update
    void Start()
    {
        float tempTransform = panels[0].rect.width;
        //Debug.Log(tempTransform);

        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].anchoredPosition = new Vector2(tempTransform * i, 0f);
        }
    }
}
