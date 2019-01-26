using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerenteTrabalho : MonoBehaviour
{
    //variável do tamanho do ciclo, em segundos (padrão 2, mas no inspector pode ser alterado)
    public float tamanhoDoCiclo = 2f;
    //controle do tempo passado
    float tempoPassadoDoCiclo;
    //variável da porcentagem do ciclo passado, entre 0 a 1;
    [HideInInspector]public float porcentagemDoCiclo;
    //o objeto que indica +$0
    public Transform símboloZeroDinheiros;
    //o objeto que indica +$100
    public Transform símboloCemDinheiros;
    //tamanho do dia
    public float tamanhoDoDia = 20;    
    //controle do horário do trabalho
    float horário;
    //chance do chefe fazer uma visita
    int chanceDoChefe;
    //indica se a janela da loja está aberta
    bool lojaAberta;
    //prefabs das animações do chefe
    public Transform[] animaçõesDoChefe;
    //transform da animação do chefe
    Transform transfDaAnimaçDoChefe;
    //indica que a animação do chefe está acontecendo
    public bool animaçChefeAcontecendo;
    //prefab da tela de fim de dia
    public Transform telaDeFimDoDiaPrefab;
    //transform da tela de fim do dia
    Transform telaDeFimDoDia;

    public Transform prefabDaLoja;
    Transform loja;

    private void Update()
    {
        //adiciona o tempo do jogo, desde o último frame, para o contado do tempo do ciclo
        tempoPassadoDoCiclo += Time.deltaTime;

        horário += Time.deltaTime;

        print(horário);

        //checa se o controle do tempo está menor que o tamanho do ciclo definido
        if (tempoPassadoDoCiclo > tamanhoDoCiclo)
        {
            //se sim, reseta o ciclo
            resetarApósErro();
        }

        //atualiza a porcentagem do ciclo
        porcentagemDoCiclo = tempoPassadoDoCiclo / tamanhoDoCiclo;

        //testa se fim do dia
        if (horário > tamanhoDoDia && !animaçChefeAcontecendo)
        {
            if (telaDeFimDoDia == null)
            {
                fecharALoja();

                telaDeFimDoDia = Instantiate(telaDeFimDoDiaPrefab);
            }
        }
    }

    //checa se deve chamar a animação do chefe
    void testaSeChefe ()
    {
        //aleatoriza a chance
        int chanceDaVisita = Random.Range(0, 100);

        //se o valor aleatorizado for menor que a chance, chama a animação
        if (chanceDaVisita < chanceDoChefe)
        {
            fecharALoja();

            //escolhe uma animação entre as disponíveis
            int indexDaAnimação = Random.Range(0, animaçõesDoChefe.Length);

            transfDaAnimaçDoChefe = Instantiate(animaçõesDoChefe[indexDaAnimação]);

            //reseta a chance do chefe aparecer
            chanceDoChefe = 0;
        }
    }

    //conta um erro (cria o objeto que indica o erro) e reseta o ciclo
    public void resetarApósErro ()
    {
        Instantiate (símboloZeroDinheiros);

        tempoPassadoDoCiclo = 0;

        chanceDoChefe += 5;

        testaSeChefe();
    }

    //conta um acerto (cria o objeto que indica o acerto), adiciona o dinheiro para o jogador e reseta o ciclo
    public void resetarApósAcerto()
    {
        Instantiate(símboloCemDinheiros);

        gerenteJogador.totalDinheiro = gerenteJogador.totalDinheiro + 100;

        tempoPassadoDoCiclo = 0;

        chanceDoChefe += 5;

        testaSeChefe();
    }

    public void abrirALoja ()
    {
        // (!animaçChefeAcontecendo)
        {
            loja = Instantiate(prefabDaLoja);
        }
    }

    public void fecharALoja ()
    {
        if (loja != null)
        {
            Destroy(loja.gameObject);
        }
    }
}