using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{
    public static timeManager instance {get; private set;}
    public float gameTime = 30.0f;
    private float timeLeft;
    private bool TimerRunning = false;
    // Start is called before the first frame update
    void Awake() {
        instance = this;
    }
    void Start()
    {
        timeLeft = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerRunning){
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0){
                timeLeft = 0;
                TimerRunning = false;
                GameManager.instance.gameOver();
            }
            UIManager.instance.timeText.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(timeLeft / 60), Mathf.FloorToInt(timeLeft % 60));
        }
    }
    public void StartTimer(){
        TimerRunning = true;
    }

    public void StopTimer(){
        TimerRunning = false;
    }

    public void ResetTimer(){
        timeLeft = gameTime;
        UIManager.instance.timeText.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(timeLeft / 60), Mathf.FloorToInt(timeLeft % 60));
    }

    public float GetTimeRemining(){
        return timeLeft;
    }

    public float GetTimeElapsed(){
        return gameTime - timeLeft;
    }
}
