using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject coin;
    public bool gameOver;
    public bool FirstTap;
    Vector3 lastPosition;
    float size;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        FirstTap = false;
        lastPosition=platform.transform.position;
        size=platform.transform.localScale.z;
    }
    // Update is called once per frame
    void Update()
    {
        if(FirstTap){
            for(int i =0; i<10; i++){
            StartSpawningPlatform();
        }
        InvokeRepeating("StartSpawningPlatform", 2f, 0.2f);
        FirstTap = false;
        }

        if(gameOver){
            CancelInvoke("StartSpawningPlatform");
        }
    }

    void StartSpawningPlatform(){
        if(counter >= 50){
            return;
        }

        int rand = Random.Range(0, 6);
        Vector3 post = lastPosition;
        if(rand <= 3){
            post.z += size;
        }else{
            post.x -= size;
        }
        Instantiate(platform,post,Quaternion.identity);
        Instantiate(coin,new Vector3(post.x,post.y+2.8f,post.z),Quaternion.Euler(0,0,89));
        lastPosition=post;
        counter++;
    }
}
