using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimits : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private float distanceX, distanceY;

    void Start()
    {
        SetMinAndMaxX();
        SetMinAndMaxY();
    }

    void LateUpdate()
    {
        CalculateX();
        CalculateY();
    }

    void CalculateX()
    {
        if(transform.position.x < minX)
        {
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }
        else if(transform.position.x > maxX)
        {
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }

    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, 0));
        maxX = bounds.x - distanceX;
        minX = -bounds.x + distanceX;
    }

    void CalculateY()
    {
        if(transform.position.y < minY)
        {
            Vector3 temp = transform.position;
            temp.y = minY;
            transform.position = temp;
        }
        else if(transform.position.y > maxY)
        {
            Vector3 temp = transform.position;
            temp.y = maxY;
            transform.position = temp;
        }
    }

    void SetMinAndMaxY()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, 0));
        maxY = bounds.y - distanceY;
        minY = -bounds.y + distanceY;
    }
}
