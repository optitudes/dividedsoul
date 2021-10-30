using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletorController : MonoBehaviour
{
    public GameObject Player;

    private Animator  animator;

    private Rigidbody2D  rigidbody2D;

    public int maxHealth=100;

    public int currentHealth=100;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth=100;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(currentHealth>0)
        // {
        //     Vector3 direction = Player.transform.position - transform.position;
        //     if(direction.x >=0.0f) transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        //     else transform.localScale = new Vector3(-3.0f, 3.0f, 3.0f);
        // }
        
    }
    public void takeDamage(int damage){
        if(currentHealth>0)
        {
        animator.SetTrigger("damaged");
        currentHealth-= damage;
        print("daño recibido");

        if(currentHealth<=0){
            enemyDie();
        }
        }
    }
    private void enemyDie(){
        animator.SetBool("dead",true);
        print("hola mundo");
        //GetComponent<Collider2D>().enabled = false;
        //Destroy(gameObject);
        print("enemigo eliminado");
       
        this.enabled = false;

    }
    private void enemyDead(){
        Destroy(gameObject);
    }
}
