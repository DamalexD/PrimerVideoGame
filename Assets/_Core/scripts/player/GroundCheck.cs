using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = false;
    public SpriteRenderer spriteRender;

    public playermovement playerMovement;

    void Start()
    {
        
    }

    void Update()
    {
        if(isGrounded){
            spriteRender.color = Color.green;
        }else{
            spriteRender.color = Color.red;
        }
    }

   protected void OnTriggerEnter2D(Collider2D other){
        isGrounded = other != null && other.tag == GameConstant.TAG_GROUND;
        if(other != null && other.tag == GameConstant.TAG_GROUND){
            playerMovement.OnLandEvent();
        }
    }

    protected void OnTriggerExit2D(Collider2D other){
        isGrounded = false;
    }
}
