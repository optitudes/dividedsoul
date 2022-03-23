using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodwinController : MonoBehaviour
{
    public GameObject Player;
    public Animator  animator;
    public Rigidbody2D  npcRB;
    public int maxHealth = 100;
    public int currentHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int damage){
        if(currentHealth > 0)
        {
            animator.SetTrigger("damaged");
            currentHealth -= damage;

            if(currentHealth <= 0){
                die();
            }
        }          
    }
    private void die(){
        //Destroy(GetComponent<BoxCollider2D>());
        animator.SetBool("dead",true);

        print("NPC is dead");
        Destroy(npcRB);
        Destroy(GetComponent<BoxCollider2D>());
        this.enabled = false;
    }
}
