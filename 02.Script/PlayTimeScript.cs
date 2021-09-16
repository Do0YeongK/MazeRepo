using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTimeScript : MonoBehaviour
{
    [SerializeField, Range(100,200)]
    private float LimitTime = 100;    //시간제한
    [SerializeField]
    private Text text_Timer;    //시간표시
    [SerializeField]
    private Text gameOver;
    [SerializeField]
    private GameObject retryButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LimitTime -= Time.deltaTime;    //일정속도로 감소
        text_Timer.text = "Time : " + Mathf.Round(LimitTime) + " s"; //Mathf.Round : 소수점 제외

        if(Mathf.Round(LimitTime) <= 0)
        {
            gameOver.text = "Game Over"; 
            retryButton.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
