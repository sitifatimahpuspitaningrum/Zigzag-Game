using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; //var instance 
    public GameObject LogoPanel;
    public GameObject TapPanel;
    public GameObject GameOverPanel;
    public GameObject liveCoin;
    public GameObject liveTime;
    public Text TotalCoin;
    public Text LeftTime;
    public Text coinText;
    public Text timeText;
    public Text numturns;
    // Start is called before the first frame update
    void Awake() {
        if(instance == null){
            instance = this;
        }
    }
    void Start()
    {
        Screen.SetResolution(720, 480, true);
        Screen.fullScreen = false;
    }

    public void GameStart(){
        TapPanel.SetActive(false);
        //LogoPanel.GetComponent<Animator>().Play("animation-Logo");
        liveCoin.SetActive(true);
        liveTime.SetActive(true);
        timeManager.instance.StartTimer();
    }

    public void gameOver(){
        liveCoin.SetActive(false);
        liveTime.SetActive(false);

        TotalCoin.text = coinText.text;
        GameOverPanel.SetActive(true);
        timeManager.instance.StopTimer();
        LeftTime.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(timeManager.instance.GetTimeElapsed() / 60), Mathf.FloorToInt(timeManager.instance.GetTimeElapsed() % 60));
        numturns.text = PlayerPrefs.GetInt("totalTurns").ToString();
    }
    // Update is called once per frame
    public void UpdateCoinText(int coinScore)
    {
         coinText.text = coinScore.ToString();
         PlayerPrefs.SetInt("coinScore", coinScore);
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
