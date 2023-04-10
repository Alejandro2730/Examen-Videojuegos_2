using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PERSONAJE1 : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    float jumFoce = 50;

    const int IDLE = 0;
    const int correr = 2;
    const int deslisar = 1;
    const int disparo = 3;
    const int saltar = 4;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.RightArrow)){
            sr.flipX = false;
            rb.velocity = new Vector2( 4, rb.velocity.y);
            ChangeAnimation(correr);
        }

        else if(Input.GetKey(KeyCode.LeftArrow)){
            sr.flipX = true;
            rb.velocity = new Vector2(-4, rb.velocity.y);
            ChangeAnimation(correr);
        }
        else if(Input.GetKey(KeyCode.Z)){
                ChangeAnimation(deslisar);
        }

        else if (Input.GetKey(KeyCode.Space)){
            rb.AddForce(transform.up*jumFoce);
        }
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
            ChangeAnimation(IDLE);
        }
        dispar();
    }
    


    private void dispar() {
        if(Input.GetKey(KeyCode.D)){
            rb.velocity = new Vector2(0, 0);
             ChangeAnimation(disparo);
        }
    }
    private void ChangeAnimation (int a){
        animator.SetInteger("Deslizar", a);
    }
}