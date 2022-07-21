using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float smoothness;
    public float yValue;
    public Vector3 offset;
    Vector3 velocity;
    public Vector3 minValues;
    public Vector3 maxValues;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame 
    void Update()
    {
        /*if(Player != null){
            Vector3 position = transform.position;
            position.x = Player.transform.position.x;
                transform.position = position
        }*/
        
    }

    void FixedUpdate(){
        cameraPosition();
    }

    void cameraPosition() {
        Vector3 target = player.transform.position + offset;
        Vector3 bounds = new Vector3(
            Mathf.Clamp(target.x, minValues.x, maxValues.x),
            yValue,
            Mathf.Clamp(target.z, minValues.z, maxValues.z));
        transform.position = Vector3.SmoothDamp(transform.position, bounds, ref velocity, smoothness);
    }
}
