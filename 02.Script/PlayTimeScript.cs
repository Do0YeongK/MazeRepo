using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTimeScript : MonoBehaviour
{
    [SerializeField, Range(100,200)]
    private float LimitTime = 100;    //�ð�����
    [SerializeField]
    private Text text_Timer;    //�ð�ǥ��
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
        LimitTime -= Time.deltaTime;    //�����ӵ��� ����
        text_Timer.text = "Time : " + Mathf.Round(LimitTime) + " s"; //Mathf.Round : �Ҽ��� ����

        if(Mathf.Round(LimitTime) <= 0)
        {
            gameOver.text = "Game Over"; 
            retryButton.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
