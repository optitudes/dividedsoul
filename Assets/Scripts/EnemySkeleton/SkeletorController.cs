using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletorController : MonoBehaviour
{
    public GameObject Player;
    public Animator  animator;
    public Rigidbody2D  skeletonRB;
    public int maxHealth = 100;
    public int currentHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
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
        if(currentHealth > 0)
        {
            animator.SetTrigger("damaged");
            currentHealth -= damage;
            print("daño recibido");

            if(currentHealth <= 0 ){
                enemyDie();
            }
        }          
        
    }
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(feetPos.position, checkRadius);
        Gizmos.DrawLine( gameObject.transform.position + new Vector3(0,0,-5), gameObject.transform.position + new Vector3(-6,0,-5));
    }
    private void enemyDie(){
        animator.SetBool("dead", true);

        print("enemigo eliminado");
        Destroy(skeletonRB);
        Destroy(GetComponent<BoxCollider2D>());
        this.enabled = false;

    }

}
