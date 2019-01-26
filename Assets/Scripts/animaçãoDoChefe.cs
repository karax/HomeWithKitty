using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animaçãoDoChefe : MonoBehaviour
{
    public float tempoDaAnimação;
    float tempoDecorrido;
    GameObject gerenteGameObject;
    gerenteTrabalho gerente;

    private void Start()
    {
        gerenteGameObject = GameObject.FindGameObjectWithTag ("GerenteTrabalho");

        gerente = gerenteGameObject.GetComponent<gerenteTrabalho>();

        gerente.animaçChefeAcontecendo = true;
    }

    void Update ()
    {
        tempoDecorrido += Time.deltaTime;

        if (tempoDecorrido > tempoDaAnimação)
        {
            Destroy(transform.gameObject);

            gerente.animaçChefeAcontecendo = false;
        }
	}
}
