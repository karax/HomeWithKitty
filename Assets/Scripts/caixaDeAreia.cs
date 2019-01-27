using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caixaDeAreia : MonoBehaviour
{
    public bool temCocô;
    SpriteRenderer sprite;
    public Sprite comCocô, semCocô;

    private void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();

        int chanceDeTerCocô = Random.Range(0, 2);

        if (chanceDeTerCocô == 0)
        {
            sprite.sprite = comCocô;

            temCocô = true;
        }
        else
        {
            sprite.sprite = semCocô;

            temCocô = false;
        }
    }

    private void OnMouseDown()
    {
        if (temCocô && gerenteGeral.quantDeAreia > 0)
        {
            sprite.sprite = semCocô;

            gerenteGeral.quantDeAreia--;

            temCocô = false;
        }
    }
}
