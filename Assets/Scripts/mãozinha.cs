using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mãozinha : MonoBehaviour
{
    float opacidade;
    //indica o tempo que o jogador poderá clicar no botão para ser considerado dinheiro ganho
    public float tamanhoDaPiscagem = .9f;
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
        //altera a opacidade para variar entre 0 e 1 apenas 
        opacidade = (gerente.porcentagemDoCiclo - tamanhoDaPiscagem) * 10;

        //opacidade variável de 0% a 100% durante cada ciclo de clique
        sprite.color = new Color(1, 1, 1, opacidade);
    }
}
