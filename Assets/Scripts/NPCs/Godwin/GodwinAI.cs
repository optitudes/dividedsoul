using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodwinAI : MonoBehaviour
{
    private int rutina;
    private float cronometro;
    private int direccion;
    public Animator animator;
    public float speedRun;
    public float attackRange = 0.5f;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public int godwinDamage = 30;
    public float lastAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if(!animator.GetBool("dead"))
        Comportamientos();   
    }

    public void Comportamientos(){

        if(!Attack()){
            animator.SetBool("run",false);
            cronometro += 1 * Time.deltaTime;
            if(cronometro >= 4){
                rutina = Random.Range(0,1);
                cronometro = 0;
            }
            switch(rutina)
            {
                case 0:
                    direccion = Random.Range(0,2);
                    rutina++;
                    break;
                case 1:
                    switch(direccion)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0,0,0);
                            transform.Translate(Vector3.right * speedRun * Time.deltaTime);
                            break;
                        case 1:
                            transform.rotation = Quaternion.Euler(0,180,0);
                            transform.Translate(Vector3.right * speedRun * Time.deltaTime);
                            break;
                    }              
                    animator.SetBool("run",true);
                    break;
            }
        }
    }

    public bool Attack()
    {
        Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        if(hitEnemies.Length == 0)
        {
            return false;
        }else{
            foreach(Collider2D enemy in hitEnemies)
                {
                    if(enemy.enabled){
                        if(Time.time>=lastAttack){
                        animator.SetTrigger("attack");
                        enemy.gameObject.SendMessage("takeDamage", godwinDamage);
                        lastAttack=Time.time+0.5f;
                    }
                        
                        
                    }
                } 
            return true;
        }
    }
}