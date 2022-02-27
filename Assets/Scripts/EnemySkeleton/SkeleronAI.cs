using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleronAI : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator animator;
    public int direccion;
    public float speed_Walk;
    public float speed_Run;
    public GameObject target;
    public bool atacando;
    public float attackRange=0.5f;
    public Transform attackPoint;
    public LayerMask playerLayer;
    public int skeletonDamage= 30;
    public float lastAttack;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("HeroKnight_0");
    }

    // Update is called once per frame
    void Update()
    {
        if(!animator.GetBool("dead"))
            Comportamientos();

    }
    public void Comportamientos(){

        if(!Attack()){
        animator.SetBool("run",false);
        cronometro += 1 * Time.deltaTime;
        if(cronometro >= 4){
            rutina = Random.Range(0,2);
            cronometro = 0;
        }
        switch(rutina)
        {
            case 0:
                animator.SetBool("walk",false);
                break;
            case 1:
                direccion = Random.Range(0,2);
                rutina++;
                break;
            case 2:
                switch(direccion)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0,0,0);
                        transform.Translate(Vector3.right * speed_Walk * Time.deltaTime);
                        break;
                    case 1:
                        transform.rotation = Quaternion.Euler(0,180,0);
                        transform.Translate(Vector3.right * speed_Walk * Time.deltaTime);
                        break;
                }
                animator.SetBool("walk",true);
                break;
        }
        }

        
    }
    public bool Attack()
    {
        Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        if(hitEnemies.Length==0)
        {
            print("no hay nada" );
            return false;

        }else{
            foreach(Collider2D enemy in hitEnemies){
                if(!enemy.GetComponent<Player>().getState()){
                    if(Time.time>=lastAttack){
                        animator.SetTrigger("attack");
                        enemy.GetComponent<Player>().takeDamage(skeletonDamage);
                        print("(esqueleto) Daño hecho");
                        lastAttack=Time.time+0.5f;
                        return true;
                    }
                
                }
            }

    }
    return true;
}
}