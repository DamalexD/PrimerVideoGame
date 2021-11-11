using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    private float horizontalVal;
    public float speed = 5;
    public float jumpForce = 7;    
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;    
    public GroundCheck groundCheck;
    private bool blockMovement = false;

    public void BlockMovement(bool _block){
        blockMovement = _block;
    }

    public void StopMovement(){
        rigidbody2D.velocity = Vector2.zero;
        //:Clown: es lo mismo
        // rigidbody2D.velocity = new Vector2(0,0);
    }
    public void DamageForce(){
        if(facingRight){
         rigidbody2D.AddForce(new Vector2(-50, 250));
        }else{
         rigidbody2D.AddForce(new Vector2(50, 250));
        }

    }

    void Awake(){
        Debug.Log("Player Movement - Awake");
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Movement - Start");
    }

    // Update is called once per frame
    void Update()
    {
        if(blockMovement){
            return;
        }
        // Debug.Log("Player Movement - Update");
        Move();
        Jump();
        Flip();

        animator.SetFloat("Speed", Mathf.Abs(horizontalVal));
    }

    private void Flip(){
        if((horizontalVal < 0 && facingRight) || (horizontalVal > 0 && !facingRight)){
            facingRight = !facingRight;
            spriteRenderer.flipX = !facingRight;
        }
        
    }

    private void Jump(){

        if(!groundCheck.isGrounded){
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            Debug.Log("Salta!!!!!!!!!!!!!1|||");
            animator.SetBool("isJumping",true);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }
    }

    public void OnLandEvent(){
        animator.SetBool("isJumping",false);
    }

    private void Move(){
        //-1 = Izquierda
        //1 = Derecha
        //Asi lo quiso la TVA (unity)
        // Debug.Log(Input.GetAxisRaw("Horizontal"));
        horizontalVal = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(horizontalVal * speed, rigidbody2D.velocity.y);
    }
    
    
}
