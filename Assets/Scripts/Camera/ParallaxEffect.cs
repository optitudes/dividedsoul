using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, starpos;
    public GameObject cam;
    public float parallaxEffect;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        starpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        print("Tamano del sprite " + obj.name  + " : " + length);
    }

    // Update is called once per frame
    void Update()
    {
        parallax();
    }

    private void parallax(){
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(starpos + dist, transform.position.y, transform.position.z);

        if(temp > starpos + length){
            transform.Translate(new Vector3(length, 0, 0));
            starpos += length;
        } 
        else if(temp < starpos - length){
            transform.Translate(new Vector3(-length, 0, 0));
            starpos -= length;
        } 
    }
}
