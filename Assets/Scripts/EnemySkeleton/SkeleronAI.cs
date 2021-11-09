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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("HeroKnight_0");
    }

    // Update is called once per frame
    void Update()
    {
        Comportamientos();
    }
    public void Comportamientos(){

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
                        //transform.position += new Vector3(1,0,0) * Time.deltaTime * speed_Walk;
                        break;
                    case 1:
                        transform.rotation = Quaternion.Euler(0,180,0);
                        transform.Translate(Vector3.right * speed_Walk * Time.deltaTime);
                        //transform.position += new Vector3(-1,0,0) * Time.deltaTime * speed_Walk;
                        break;
                }
                animator.SetBool("walk",true);
                break;
        }
    }
}
