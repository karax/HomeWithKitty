using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class símbolosGanho : MonoBehaviour
{
    public float impulsoVertical = 1;
    float gravidade = -.01f;
    float grauAleatório;
    float tempoDeVidaMax = 2;
    float tempoDeVidaAtual;

    private void Start()
    {
        //aleatoriza um valor em graus para lançar o objeto horizontalmente
        grauAleatório = (float)Random.Range(-100, 100) / (float)1000;
    }

    private void Update()
    {
        //indica a direção vertical que o objeto deve ir, dependendo do tempo
        impulsoVertical = impulsoVertical + gravidade;

        //indica a direção horizontal e vertical para o objeto se deslocar
        transform.Translate(Vector2.up * impulsoVertical + Vector2.right * grauAleatório);

        //checa quanto tempo o objeto existe
        tempoDeVidaAtual = tempoDeVidaAtual + Time.deltaTime;

        //checa se o objeto existe a mais tempo do que o permitido dele existir
        if (tempoDeVidaAtual > tempoDeVidaMax)
        {
            //se sim, auto-destrua
            Destroy(transform.gameObject);
        }
    }

}
