using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petisco : MonoBehaviour
{
    Vector2 cursor;
    bool seguirCursor = true;

    private void Update()
    {
        cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (seguirCursor)
        {
            transform.position = cursor;
        }
        
        if (Input.GetMouseButton(0))
        {
            seguirCursor = false;
        }
    }
}
