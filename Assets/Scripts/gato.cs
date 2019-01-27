using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gato : MonoBehaviour {

    public float health;

    private Rigidbody2D rigidbody2d;
    public Transform catTransform;

    public float catMovementSpeed;
    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    public int walkDirection;
    public Vector3 currRot;
    public int directionBefore;

    // Use this for initialization
    void Start () {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        catTransform = this.transform;
        waitCounter = 1;
        walkCounter = 2;
        walkDirection = 1;
        currRot = catTransform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 myVel = rigidbody2d.velocity;
        myVel.x = catMovementSpeed;
        rigidbody2d.velocity = myVel;
       

        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            switch (walkDirection)
            {
                case 0:                
                    rigidbody2d.velocity = new Vector2(1, 0);
                    currRot.y = 180;
                    catTransform.eulerAngles = currRot;
                    break;
                case 1:
                    rigidbody2d.velocity = new Vector2(-1, 0);
                    currRot.y = 0;
                    catTransform.eulerAngles = currRot;
                    break;
            }
        
            if (walkCounter < 0)
            {
                isWalking = false;
                walkCounter = 2;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            rigidbody2d.velocity =  Vector2.zero;
            if(waitCounter < 0)
            {
                ChooseDirection();
                waitCounter = 1;
            }
        }

    }

    public void ChooseDirection()
    {      
        walkDirection = Random.Range(0, 2);
        isWalking = true;
    }
}
