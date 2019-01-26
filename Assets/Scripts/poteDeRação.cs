using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poteDeRação : MonoBehaviour {

    public bool temRação;

    private void OnMouseDown()
    {
        if (gerenteGeral.quantDeRação >0 && !temRação)
        {
            temRação = true;

            gerenteGeral.quantDeRação--;
        }
    }
}
