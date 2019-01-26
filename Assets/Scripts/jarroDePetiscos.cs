using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jarroDePetiscos : MonoBehaviour
{
    public Transform petisco;

    private void OnMouseUp()
    {
        if (gerenteGeral.quantDePetiscos > 0)
        {
            Instantiate(petisco);

            gerenteGeral.quantDePetiscos--;
        }
    }
}
