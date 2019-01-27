using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerenteCasa : MonoBehaviour
{
    public bool visitadoPeloVet;
    public bool nãoSpawnarGato;
    bool perdeu;
    public Transform prefabVeterinário;
    Transform veterinário;
    public Transform telaPreta;
    public float tempoTelaPretaTotal;
    float tempoTelaPretaAtual;
    float porcentagemTelaPreta;
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        sprite.color = new Color(1, 1, 1, 0);

        if (nãoSpawnarGato)
        {
            perdeu = true;
        }
    }

    private void Update()
    {
        if (gerenteGeral.saúdeAtualDoGato <= 0 && !visitadoPeloVet)
        {
            visitadoPeloVet = true;

            veterinário = Instantiate(prefabVeterinário);
        }

        if (perdeu)
        {
            tempoTelaPretaAtual += Time.deltaTime;

            porcentagemTelaPreta = tempoTelaPretaAtual / tempoTelaPretaTotal;

            sprite.color = new Color(1, 1, 1, porcentagemTelaPreta);

            if (porcentagemTelaPreta == 1)
            {
                //ir para a tela inicial
            }
        }


    }


}
