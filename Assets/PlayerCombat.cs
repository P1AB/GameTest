using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator Animator;
    public Transform attackPoint;
    public float attackRange = 0.15f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime){
                if(Input.GetKeyDown(KeyCode.Mouse0)){
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if(Input.GetKeyDown(KeyCode.Mouse1)){
                Block();
            }
        }
    }
    void Attack(){
        //play attack animation
        Animator.SetTrigger("Attack");
        //detect hit enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    void Block(){
        Animator.SetTrigger("Block");
    }
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null){
            return;
        }
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
