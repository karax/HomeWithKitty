using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolinha : MonoBehaviour
{
    TargetJoint2D mola;
    Vector2 cursor;
    Vector2 posiçãoAnterior;
    SpriteRenderer sprite;
    public Sprite bola, rato;
    public bool emMovimento;
    public bool boolRato, boolBola = true;

    private void Start()
    {
        mola = transform.GetComponent<TargetJoint2D>();

        mola.enabled = false;

        sprite = transform.GetComponent<SpriteRenderer>();

        if (boolRato)
        { sprite.sprite = rato; } 
        else if (boolBola)
        { sprite.sprite = bola; }

    }

    private void Update()
    {
        cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            mola.target = cursor;
        }

        if (Vector2.Distance(posiçãoAnterior, transform.position) > .1f)
        { emMovimento = true; }
        else
        { emMovimento = false; }

        posiçãoAnterior = transform.position;
    }

    private void OnMouseDrag()
    {
        mola.enabled = true;
    }

    private void OnMouseUp()
    {
        mola.enabled = false;
    }

    public void mudaSpriteRato ()
    {
        sprite.sprite = rato;
    }

    public void mudaSpriteBola()
    {
        sprite.sprite = bola;
    }
}
