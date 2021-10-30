using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Col;
    public Renderer Background;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<21;i++){
            Instantiate(Col, new Vector2(-10 + i, -2.49f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
