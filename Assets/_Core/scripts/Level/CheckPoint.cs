using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Flaggggggggggggggggggg!!1111!!|||");
        animator.SetBool("isFlaging",true);

        // LevelManager.Ins.AddCoins();
        // GameObject.Destroy(this.gameObject);
    }
}
