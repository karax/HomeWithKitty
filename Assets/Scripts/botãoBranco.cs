using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botãoBranco : MonoBehaviour
{
    public Transform gerenteTransform;
    gerenteTrabalho gerente;

    private void Start()
    {
        //busca o componente gerenteTransform no gerente na cena
        gerente = gerenteTransform.GetComponent<gerenteTrabalho>();
    }

    //quando for clicado em cima desse objeto
    private void OnMouseDown()
    {
        //checa se o ciclo está no ponto em que o dinheiro deve ser ganho
        if (gerente.porcentagemDoCiclo >= .8f)
        {
            //se sim, indica para o gerente que houve um acerto
            gerente.resetarApósAcerto();
        }
        //se não, indica para o gerente que houve um erro
        else
        {
            gerente.resetarApósErro();
        }
    }

}
