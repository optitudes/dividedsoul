using UnityEngine;

public class Player : MonoBehaviour
{
    public float         fuerzaSalto;
    public float         velocidad;
    public Rigidbody2D  playerRB;
    public Animator     animator;
    public int maxHealth=100;
    public int currentHealth=100; 

    public float jumpTimeCounter;
    public float jumpTime;
    bool isJumping = false;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        //rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        jumpManager();
    }

    private void FixedUpdate()
    {
        if(!animator.GetBool("dead"))
            movementManager();
    }

    private void movementManager(){

        float inputX = Input.GetAxisRaw("Horizontal");

        playerRB.velocity = new Vector2(inputX * velocidad, playerRB.velocity.y);

        animator.SetFloat("Speed",Mathf.Abs(inputX));

        animator.SetFloat("JumpSpeed",Mathf.Abs(playerRB.velocity.y));

        if (inputX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (inputX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        /*if(Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(playerRB.velocity.y) < 0.001f){
            playerRB.AddForce(new Vector2(0,fuerzaSalto));300   
        }*/
    }


    void jumpManager()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            playerRB.velocity = Vector2.up * fuerzaSalto;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                playerRB.velocity = Vector2.up * fuerzaSalto;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPos.position, checkRadius);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            animator.SetFloat("JumpSpeed",0.0f);
        }
    }
    public void takeDamage(int damage){
        if(currentHealth>0 && !animator.GetBool("dead"))
        {
            animator.SetTrigger("damaged");
            currentHealth-= damage;
            print("daño recibido(player)");
            if(currentHealth<=0 ){
                playerDie();
            }
        }
    }
    private void playerDie(){
        
        this.enabled = false;
        animator.SetBool("dead",true);
        Destroy(playerRB);
        Destroy(GetComponent<BoxCollider2D>());
        print("jugador eliminado");
        playerRB.velocity = Vector2.up * 0; //(0,1)*0  --> new Vector2(0,0)

    }

    public bool getState(){
        return animator.GetBool("dead");
    }

}

