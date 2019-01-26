using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botãoDeFecharALoja : MonoBehaviour
{
    GameObject gerenteGameObject;
    gerenteTrabalho gerente;

    private void Start()
    {
        gerenteGameObject = GameObject.FindGameObjectWithTag("GerenteTrabalho");

        gerente = gerenteGameObject.GetComponent<gerenteTrabalho>();
    }

    private void OnMouseDown()
    {
        gerente.fecharALoja();
    }
}
