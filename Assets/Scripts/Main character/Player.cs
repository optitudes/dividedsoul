using UnityEngine;

public class Player : MonoBehaviour
{
    public float         fuerzaSalto;
    public float         velocidad;
    private Rigidbody2D  rigidbody2D;
    private Animator     animator;
    private int          m_facingDirection = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed",Mathf.Abs(inputX*velocidad));

        animator.SetFloat("JumpSpeed",Mathf.Abs(rigidbody2D.velocity.y));

        if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            m_facingDirection = 1;
        }
        else if (inputX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            m_facingDirection = -1;
        }
        if(Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rigidbody2D.velocity.y) < 0.001f){
            rigidbody2D.AddForce(new Vector2(0,fuerzaSalto));
        }
        
        
        transform.position += new Vector3(inputX,0,0) * Time.deltaTime * velocidad;
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            animator.SetFloat("JumpSpeed",0.0f);
        }
    }
}
