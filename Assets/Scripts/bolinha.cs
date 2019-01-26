using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolinha : MonoBehaviour
{
    TargetJoint2D mola;
    Vector2 cursor;

    private void Start()
    {
        mola = transform.GetComponent<TargetJoint2D>();

        mola.enabled = false;
    }

    private void Update()
    {
        cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            mola.target = cursor;
        }
    }

    private void OnMouseDrag()
    {
        mola.enabled = true;
    }

    private void OnMouseUp()
    {
        mola.enabled = false;
    }


}
