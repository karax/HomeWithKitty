using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poteDeRação : MonoBehaviour
{
    public bool temRação;
    SpriteRenderer sprite;
    public Sprite poteCheio, poteVazio;
    
    private void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (gerenteGeral.quantDeRação >0 && !temRação)
        {
            temRação = true;

            sprite.sprite = poteCheio;

            gerenteGeral.quantDeRação--;
        }
    }

    private void Update()
    {
        if (!temRação && sprite.sprite != poteVazio)
        {
            sprite.sprite = poteVazio;
        }
    }
}
