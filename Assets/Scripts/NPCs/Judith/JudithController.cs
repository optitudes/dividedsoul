using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudithController : MonoBehaviour
{
    public GameObject prefabText;
    public Transform Hero;
    public Transform Judith;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void speak(string message)
    {
        print(message);
        GameObject text=Instantiate(prefabText);
        if(Judith.position.x > Hero.position.x){
            Judith.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else{
            Judith.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        text.transform.position= new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
    }
}
