using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petisco : MonoBehaviour
{
    Vector2 cursor;
    bool seguirCursor = true;
    jarroDePetiscos jarro;
    gato gato;

    private void Start()
    {
        jarro = GameObject.FindGameObjectWithTag("jarroDePetiscos").GetComponent<jarroDePetiscos>();
        gato = GameObject.FindGameObjectWithTag("Gato").GetComponent<gato>();
    }

    private void Update()
    {
        cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gato.petiscoTransf = transform;

        if (seguirCursor)
        {
            transform.position = cursor;
        }
        
        if (Input.GetMouseButton(0))
        {
            seguirCursor = false;

            jarro.petiscoNoChão = true;
        }
    }
}
