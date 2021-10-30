using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float        lastAttack;
    public Transform attackPoint;
    public float attackRange=0.5f;
    public LayerMask enemyLayers;
    public int playerDamage= 30;
    private Rigidbody2D  rigidbody2D;
    private Animator     animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && Time.time > lastAttack + 0.50f){
            Attack1();
            lastAttack= Time.time;
        }
    }
    private void Attack1(){

        animator.SetTrigger("attack");
        Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<SkeletorController>().takeDamage(playerDamage);
            print("Daño hecho");

        }
        
    }
    private void OnDrawGizmosSelected(){
        if(attackPoint == null)return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
