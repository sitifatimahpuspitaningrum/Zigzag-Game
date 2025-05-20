using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    public bool gameOver;
    Vector3 offset; //distance camera from ball
    // Start is called before the first frame update
    void Start()
    {
        offset = ball.transform.position - transform.position;
        gameOver=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver){
            Follow();
        }
    }
    
    void Follow(){
        Vector3 pos = transform.position; //current camera position
        Vector3 targetpos = ball.transform.position - offset; 
        transform.position = Vector3.Lerp(pos,targetpos,Time.deltaTime);
    }
}
