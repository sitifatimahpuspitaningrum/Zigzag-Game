using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;

    void Awake (){
        if (instance == null){
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart(){
        UIManager.instance.GameStart();
        scoreManager.instance.StartScore();
    }

    public void gameOver(){
        UIManager.instance.gameOver();
        scoreManager.instance.TotalScore();
    }
}
