using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float        lastAttack;
    public Transform attackPoint;
    public float attackRange=0.5f;
    public LayerMask enemyLayers;
    public int playerDamage = 30;
    public Rigidbody2D  playerRB;
    public Animator     animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.X) && Time.time > lastAttack + 0.50f && !animator.GetBool("dead")){
            Attack1();
            lastAttack = Time.time;
        }
    }
    private void Attack1(){

        animator.SetTrigger("attack");
        Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.enabled){
                enemy.gameObject.SendMessage("takeDamage", playerDamage);
                //enemy.gameObject.GetComponent<SkeletorController>().takeDamage(playerDamage);
                print("Daño hecho");
            }
        }
        
    }
    private void OnDrawGizmosSelected(){
        if(attackPoint == null)return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    // rB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed, rB.velocity.y);
}
