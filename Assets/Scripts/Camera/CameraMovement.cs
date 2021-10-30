using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null){
            Vector3 position = transform.position;
            position.x = Player.transform.position.x;
            transform.position = position;
        }
    }
}
