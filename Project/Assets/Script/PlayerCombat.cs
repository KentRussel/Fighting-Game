using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int AttackDamage = 20;
    public float attackRate = 1f;
    float nextAttackTime = 0f; 


     private void Awake ()
    {
         animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
              Attack();
              nextAttackTime = Time.time + 2f / attackRate;
            }
        }
    }

    void Attack()
    {
        //play an attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage them
        foreach(Collider2D enemyMelee in hitEnemies)
        {
            enemyMelee.GetComponent<EnemyMelee>().TakeDamage1(AttackDamage);
        }
    }

    void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
