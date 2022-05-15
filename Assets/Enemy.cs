using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth = 100;
    public Animator Animator;
    public Rigidbody2D rb;
    // Update is called once per frame
    void Start()
    {
        currentHealth = maxHealth;
        Animator.SetBool("Dead", false);
    }

    public void TakeDamage(int damage){
        //take damage
        currentHealth -= damage;
        //play animation
        Animator.SetTrigger("Hurt");
        //check die
        if( currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Debug.Log("enemy died");
        //Die animation
        Animator.SetBool("Dead", true);
        //disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

}
