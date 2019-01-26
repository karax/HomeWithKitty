using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class círculoCinza : MonoBehaviour
{
    float escala;
    SpriteRenderer sprite;
    public Transform gerenteTransform;
    gerenteTrabalho gerente;
    
    private void Start()
    {
        //busca o componente SpriteRender do próprio objeto
        sprite = GetComponent<SpriteRenderer>();

        //busca o componente gerenteTransform no gerente na cena
        gerente = gerenteTransform.GetComponent<gerenteTrabalho>();
    }

    private void Update()
    {
        //opacidade variável de 0% a 100% durante cada ciclo de clique
        sprite.color = new Color(1, 1, 1, gerente.porcentagemDoCiclo);

        //muda o valor da escala entre entre 3 e 0.5 durante cada ciclo de clique
        escala = (1 - gerente.porcentagemDoCiclo) * 2.5f + .5f;

        //muda efetivamente a escala do objeto 
        transform.localScale = new Vector3(escala, escala, escala);
    }



}
