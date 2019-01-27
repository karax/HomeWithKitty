using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jarroDePetiscos : MonoBehaviour
{
    public Transform petiscoPrefab;
    public bool petiscoNoChão;
    SpriteRenderer sprite;
    public Sprite poteCheio, poteVazio;
    public Transform petiscoInstanciado;

    private void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
    }

    private void OnMouseUp()
    {
        if (gerenteGeral.quantDePetiscos > 0 && !petiscoNoChão)
        {
            petiscoInstanciado = Instantiate(petiscoPrefab);

            gerenteGeral.quantDePetiscos--;
        }
    }

    private void Update()
    {
        if (gerenteGeral.quantDePetiscos<=0 && sprite.sprite != poteVazio)
        {
            sprite.sprite = poteVazio;
        }
    }
}
