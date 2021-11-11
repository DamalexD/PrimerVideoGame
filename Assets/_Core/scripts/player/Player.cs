using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public playermovement PlayerMovement;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteHitBlanco;
    public Animator animator; 
    private int lifes = 3;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Enemy"){
            Debug.Log("Ay mi madreeeee me golpiaronnnnn");
            OnDamage();
        }
    }

    private bool esInmune = false;

    private void OnDamage(){
        if(esInmune){return;}

        lifes--;

        if(lifes < 0){

            LevelManager.Ins.GameOver();
            return;
        }

        LevelManager.Ins.OnPlayerDamage(lifes);
        Debug.Log("player lifes: "+lifes);
        esInmune = true;
        //parar al individuo videojugador
        PlayerMovement.BlockMovement(true);
        PlayerMovement.StopMovement();

        //aplicar animacion para que jale el sprite blanco
        animator.enabled = false;
        spriteRenderer.sprite = spriteHitBlanco;

        //el individuo c va patras
        PlayerMovement.DamageForce();

        //Parpadeo de inmunidad :O        
        InvokeRepeating("Parpadeo", 0, 0.3f);

        //Y volvemos a la normalidad
        Invoke("BackToNormal", 1);
        
    }

    private void BackToNormal(){
        esInmune = false;

        PlayerMovement.BlockMovement(false);
        animator.enabled = true;
        CancelInvoke("Parpadeo");
        spriteRenderer.enabled = true;
    }

    private void Parpadeo(){
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }
}
