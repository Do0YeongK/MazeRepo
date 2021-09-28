using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    [SerializeField]
    private float CountDown = 3f;    //�ð�����
    [SerializeField]
    private GameObject CountDownText;    //�ð�ǥ��

    [SerializeField]
    private GameObject JoystickCanvas;  //���̽�ƽ Canvas

    private void Start()
    {
        CountDownText.GetComponent<Text>().text = Mathf.Round(CountDown) + "";
        //position�̵� ���ϰ� ���̽�ƽ Canvas SetActive=false��
        JoystickCanvas.SetActive(false);
        StartCoroutine(ActiveJoyStick(CountDown));
    }
    private void Update()
    {
        CountDown -= Time.deltaTime;    //�����ӵ��� ����
        CountDownText.GetComponent<Text>().text = Mathf.Round(CountDown)+""; //Mathf.Round : �Ҽ��� ����

        if (Mathf.Round(CountDown) <= 0)
        {
            CountDownText.GetComponent<Text>().text = "Start";
        }
        Invoke("StartCount", CountDown + 1);    //CountDown�ϰ� 1�� �ڿ� ���� ������� 
    }

    void StartCount()
    {
        CountDownText.SetActive(false);
    }

    IEnumerator ActiveJoyStick(float countDown) //countdown������ ���̽�ƽ ����
    {
        yield return new WaitForSeconds(countDown);
        JoystickCanvas.SetActive(true);
    }
}
