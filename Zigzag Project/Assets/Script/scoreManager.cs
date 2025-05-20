using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    public int score;
    private int numTurns;
    private int CoinCount;
    private float timeElapsed;

    void Awake() {
        if (instance == null){
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TotalScore(){
        numTurns = PlayerPrefs.GetInt("totalTurns");
        CoinCount = PlayerPrefs.GetInt("coinScore");
        timeElapsed = Mathf.Floor(timeManager.instance.GetTimeElapsed());

        //score = (numTurns * 10) + (CoinCount * 10) - Mathf.RoundToInt(timeElapsed * 5);
        //Debug.Log("score = (" + numTurns + " * 10) + (" + CoinCount + " * 10) - (" + timeElapsed + " * 5) = " + score);
        //PlayerPrefs.SetInt("score", score);
    }

    public void StartScore(){
        
    }

    public void StopScore(){
        PlayerPrefs.SetInt("score", score);
    }
}
