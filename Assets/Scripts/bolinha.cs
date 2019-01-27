using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolinha : MonoBehaviour
{
    TargetJoint2D mola;
    Vector2 cursor;
    Vector2 posiçãoAnterior;
    SpriteRenderer sprite;
    Rigidbody2D rigidbody;
    public Sprite bola, rato;
    public bool emMovimento;
    bool continPulando;
    float continPulandoAtual, continPulandoTotal = 2f;
    public bool boolRato, boolBola = true;

    private void Start()
    {
        mola = transform.GetComponent<TargetJoint2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = transform.GetComponent<SpriteRenderer>();

        mola.enabled = false;

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

        if(Input.GetKeyDown(KeyCode.A))
        {
            pular();
        }

        if (continPulandoAtual > 0)
        {
            continPulandoAtual -= Time.deltaTime;
        }
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

    public void pular ()
    {
        if (continPulandoAtual <= 0)
        {
            continPulandoAtual = continPulandoTotal;

            float velVertical = Random.Range(200, 350);
            float velHorizontal = Random.Range(-250, 250);

            rigidbody.AddForce(new Vector2(velHorizontal, velVertical));
        }
    }
}
