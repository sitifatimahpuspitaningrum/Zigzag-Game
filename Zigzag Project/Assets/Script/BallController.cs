using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed = 17f;
    private Vector3 dir;
    public GameObject ball;
    public GameObject effect;
    public GameObject PlatformSpawner;
    Rigidbody rb;
    bool started;
    int coinScore;
    int numturns;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
       started = false;
       dir = Vector3.zero;
       coinScore = 0;
       numturns = 0;
    }

    void Update(){
        if(Input.GetKeyDown("space")){
            if(dir == Vector3.forward){
                dir = Vector3.left;
            }else{
                dir = Vector3.forward;
            }
            numturns++;
            PlayerPrefs.SetInt("numturns", numturns);
            int totalTurns = numturns;
            PlayerPrefs.SetInt("totalTurns", totalTurns);

            if(!started){
                GameManager.instance.GameStart();
                PlatformSpawner.GetComponent<PlatformSpawner>().FirstTap = true;
            }
        }

        float amoutToMove = speed*Time.deltaTime;
        transform.Translate(dir * amoutToMove);

        if (!Physics.Raycast(transform.position, Vector3.down, 1)) // if raycast not hitting anything / ball falling off
        {
            GameManager.instance.gameOver();
            rb.velocity = new Vector3(0,-25,0);
            Destroy(gameObject, 1.0f);
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            PlatformSpawner.GetComponent<PlatformSpawner>().gameOver=true;
        }
    }

    void OnTriggerEnter(Collider obj) {
        if(obj.gameObject.tag == "coin"){
            GameObject ef = Instantiate(effect,obj.gameObject.transform.position,Quaternion.identity);
            Destroy(obj.gameObject);
            Destroy(ef, 1f);
            coinScore += 1;
            UIManager.instance.UpdateCoinText(coinScore);
        }
    }
}
