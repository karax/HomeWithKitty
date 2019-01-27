
using UnityEngine;

public class gato : MonoBehaviour
{
    public float health;

    private Rigidbody2D rigidbody;
    
    public float tamanhoDoGato;

    float tempoIdleInicial;
    bool idleInicial;

    jarroDePetiscos jarroDePetiscos;
    [HideInInspector] public Transform petiscoTransf;
    public float TempoAnimaçComendoTotal;
    float tempoAnimaçComendoAtual;

    bolinha brinquedo;
    GameObject brinquedoObj;
    float tempoAtençãoBrinquedoAtual;
    public float tempoAtençãoBrinquedoTotal;
    public float TempoAnimaçBrinksTotal;
    float tempoAnimaçBrinksAtual;

    poteDeRação poteDeRação;
    GameObject poteDeRaçãoObj;
    public float tempoAnimaçComerTotal;
    float tempoAnimaçComerAtual;

    int direçAleatVagar;
    public float tempoDeVagarTotal;
    float tempoDeVagarAtual;

    float tempoDeMudarAção;
    bool vagando, brincando, comendo, petisco;
    bool praticandoAção;
    
    private float catMovementSpeed;
    public bool isWalking;
    private float walkTime;
    private float walkCounter;
    private float waitTime;
    private float waitCounter;
    private int walkDirection;
    public Vector2 rotaçãoAtual;

    gerenteCasa gerenteCasa;

    void Start ()
    {
        jarroDePetiscos = GameObject.FindGameObjectWithTag("jarroDePetiscos").GetComponent<jarroDePetiscos>();
        brinquedoObj = GameObject.FindGameObjectWithTag("Brinquedo");
        brinquedo = brinquedoObj.GetComponent<bolinha>();
        poteDeRaçãoObj = GameObject.FindGameObjectWithTag("Tijela");
        poteDeRação = poteDeRaçãoObj.GetComponent<poteDeRação>();
        gerenteCasa = GameObject.FindGameObjectWithTag("Casa").GetComponent<gerenteCasa>();

        tempoIdleInicial = 3;

        rigidbody = transform.GetComponent<Rigidbody2D>();
        waitCounter = 1;
        walkCounter = 2;
        walkDirection = 1;
        rotaçãoAtual = transform.eulerAngles;

        if (gerenteCasa.nãoSpawnarGato)
        {
            Destroy(transform.gameObject);
        }
	}
	
	void Update ()
    {
        tempoDeMudarAção -= Time.deltaTime;

        tempoIdleInicial -= Time.deltaTime;
        if (tempoIdleInicial < 0)
        {
            idleInicial = true;
        }
        if (idleInicial)
        {
            //se houver algum petisco, o gato vai até ele e come
            if ((tempoDeMudarAção <= 0 && jarroDePetiscos.petiscoNoChão && !brincando && !comendo && !vagando) || petisco)
            {
                petisco = true;

                if (Vector2.Distance(transform.position, jarroDePetiscos.petiscoInstanciado.position) > tamanhoDoGato)
                {
                    //muda sprite para animação de andando

                    if (transform.position.x - jarroDePetiscos.petiscoInstanciado.position.x < 0)
                    {
                        rigidbody.velocity = new Vector2(3, 0);
                        rotaçãoAtual.y = 0;
                        transform.eulerAngles = rotaçãoAtual;
                    }
                    else
                    {
                        rigidbody.velocity = new Vector2(-3, 0);
                        rotaçãoAtual.y = 180;
                        transform.eulerAngles = rotaçãoAtual;
                    }

                    if (tempoAnimaçComendoAtual != TempoAnimaçComendoTotal)
                    {
                        tempoAnimaçComendoAtual = TempoAnimaçComendoTotal;
                    }
                }
                else if (petiscoTransf != null && tempoAnimaçComendoAtual > 0)
                {
                    tempoAnimaçComendoAtual -= Time.deltaTime;

                    //muda sprite para animação de comendo
                }
                else if (petiscoTransf != null && tempoAnimaçComendoAtual <= 0)
                {
                    Destroy(petiscoTransf.gameObject);

                    petisco = false;

                    tempoDeMudarAção = 1.5f;

                    jarroDePetiscos.petiscoNoChão = false;

                    //adiciona pontos de saúde ao gato

                    //muda sprite para idle
                }
            }
            //se a bolinha estiver em movimento, o gato começa a brincar com ela
            else if ((tempoDeMudarAção <= 0 && brinquedo.emMovimento && !petisco && !comendo /*&& !vagando*/ && gerenteGeral.saciaçãoAtualdoDoGato > 25) || brincando)
            {
                brincando = true;

                /*tempoAtençãoBrinquedoAtual -= Time.deltaTime;

                if (brinquedo.emMovimento)
                {
                    tempoAtençãoBrinquedoAtual = tempoAtençãoBrinquedoTotal;
                }*/

                if (Vector2.Distance(transform.position, brinquedoObj.transform.position) > tamanhoDoGato)
                {
                    //muda sprite para animação de andando

                    if (transform.position.x - brinquedoObj.transform.position.x < 0)
                    {
                        rigidbody.velocity = new Vector2(5, 0);
                        rotaçãoAtual.y = 0;
                        transform.eulerAngles = rotaçãoAtual;
                    }
                    else
                    {
                        rigidbody.velocity = new Vector2(-5, 0);
                        rotaçãoAtual.y = 180;
                        transform.eulerAngles = rotaçãoAtual;
                    }

                    if (tempoAnimaçBrinksAtual != TempoAnimaçBrinksTotal)
                    {
                        tempoAnimaçBrinksAtual = TempoAnimaçBrinksTotal;
                    }
                }
                else if (tempoAnimaçBrinksAtual > 0)
                {
                    tempoAnimaçBrinksAtual -= Time.deltaTime;

                    //muda sprite para animação de brincando
                }
                else if (tempoAnimaçBrinksAtual <= 0)
                {
                    brinquedo.pular();

                    brincando = false;

                    tempoDeMudarAção = 1.5f;
                }
            }
            else if ((tempoDeMudarAção <= 0 && poteDeRação.temRação && !brinquedo.emMovimento && !petisco && gerenteGeral.saciaçãoAtualdoDoGato <= 50) || comendo)
            {
                comendo = true;

                if (Vector2.Distance(transform.position, poteDeRaçãoObj.transform.position) > tamanhoDoGato)
                {
                    //muda sprite para animação de andando

                    if (transform.position.x - poteDeRaçãoObj.transform.position.x < 0)
                    {
                        rigidbody.velocity = new Vector2(3, 0);
                        rotaçãoAtual.y = 0;
                        transform.eulerAngles = rotaçãoAtual;
                    }
                    else
                    {
                        rigidbody.velocity = new Vector2(-3, 0);
                        rotaçãoAtual.y = 180;
                        transform.eulerAngles = rotaçãoAtual;
                    }
                }
                else if (tempoAnimaçComendoAtual > 0)
                {
                    tempoAnimaçBrinksAtual -= Time.deltaTime;

                    //muda sprite para animação de comendo
                }
                else if (tempoAnimaçComendoAtual <= 0)
                {
                    poteDeRação.gatoComer();

                    comendo = false;

                    tempoDeMudarAção = 1.5f;
                }
            }
            //gato fica vagando
            else if ((tempoDeMudarAção <= 0 && !brinquedo.emMovimento && !petisco && !comendo && gerenteGeral.saciaçãoAtualdoDoGato > 25) || vagando)
            {
                if (!vagando)
                {
                    direçAleatVagar = Random.Range(0, 2);

                    tempoDeVagarAtual = tempoDeVagarTotal;
                }

                vagando = true;

                switch (direçAleatVagar)
                {
                    case 0:
                        rigidbody.velocity = new Vector2(2, 0);
                        rotaçãoAtual.y = 0;
                        transform.eulerAngles = rotaçãoAtual;
                        break;
                    case 1:
                        rigidbody.velocity = new Vector2(-2, 0);
                        rotaçãoAtual.y = 180;
                        transform.eulerAngles = rotaçãoAtual;
                        break;
                }

                if (tempoDeVagarAtual > 0)
                {
                    tempoDeVagarAtual -= Time.deltaTime;
                }

                if (tempoDeVagarAtual <= 0)
                {
                    vagando = false;

                    tempoDeMudarAção = 1.5f;
                }
            }
            else
            {
                //gato vai até o pote e fica miando
            }
        }
    }
}
