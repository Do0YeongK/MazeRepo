using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    [SerializeField]
    private float CountDown = 3f;    //시간제한
    [SerializeField]
    private GameObject CountDownText;    //시간표시

    [SerializeField]
    private GameObject JoystickCanvas;  //조이스틱 Canvas

    private void Start()
    {
        CountDownText.GetComponent<Text>().text = Mathf.Round(CountDown) + "";
        //position이동 못하게 조이스틱 Canvas SetActive=false로
        JoystickCanvas.SetActive(false);
        StartCoroutine(ActiveJoyStick(CountDown));
    }
    private void Update()
    {
        CountDown -= Time.deltaTime;    //일정속도로 감소
        CountDownText.GetComponent<Text>().text = Mathf.Round(CountDown)+""; //Mathf.Round : 소수점 제외

        if (Mathf.Round(CountDown) <= 0)
        {
            CountDownText.GetComponent<Text>().text = "Start";
        }
        Invoke("StartCount", CountDown + 1);    //CountDown하고 1초 뒤에 글자 사라지게 
    }

    void StartCount()
    {
        CountDownText.SetActive(false);
    }

    IEnumerator ActiveJoyStick(float countDown) //countdown끝나고 조이스틱 생성
    {
        yield return new WaitForSeconds(countDown);
        JoystickCanvas.SetActive(true);
    }
}
