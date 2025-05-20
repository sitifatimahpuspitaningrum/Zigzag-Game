using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider obj) {
        if(obj.gameObject.tag == "ball"){
            Invoke("falldown", 0.2f);
        }
    }

    void falldown(){
        GetComponentInParent<Rigidbody>().useGravity=true;
        GetComponentInParent<Rigidbody>().isKinematic=false;
        Destroy(transform.parent.gameObject, 2.0f);
    }
}