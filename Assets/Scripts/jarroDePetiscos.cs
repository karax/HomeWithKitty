using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jarroDePetiscos : MonoBehaviour
{
    public Transform petisco;
    public bool temPetiscos;
    SpriteRenderer sprite;
    public Sprite poteCheio, poteVazio;

    private void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
    }

    private void OnMouseUp()
    {
        if (gerenteGeral.quantDePetiscos > 0)
        {
            Instantiate(petisco);

            gerenteGeral.quantDePetiscos--;
        }
    }

    private void Update()
    {
        if (!temPetiscos && sprite.sprite != poteVazio)
        {
            sprite.sprite = poteVazio;
        }
    }
}
