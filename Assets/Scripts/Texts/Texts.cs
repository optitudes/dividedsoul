using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texts : MonoBehaviour
{
    public float tiempoVida= 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoVida-=Time.deltaTime;
        if(tiempoVida<=0)
        {
            Destroy(this.gameObject);
        }
        
    }
}
