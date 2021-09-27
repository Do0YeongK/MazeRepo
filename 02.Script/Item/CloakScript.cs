using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloakScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject cloakSlot;

    [SerializeField]
    private Text cloak_Timer;   //���ѽð� ī��Ʈ ǥ��
    private float timeLimit = 6f; //���ѽð�

    public void MakeInvisibility()
    {
        cloakSlot.SetActive(false);
        player.SetActive(false);
        StartCoroutine(countTime(1f));  //1�ʸ��� ����
        Invoke("UndoInvisibility", timeLimit);    //���ѽð����� �Ⱥ���
        Invoke("UndoTimer", timeLimit);    //���ѽð����� �Ⱥ���
    }

     void UndoInvisibility()
    {
        player.SetActive(true);
    }

    IEnumerator countTime(float delayTime)
    {
        cloak_Timer.text = "Timer : " + timeLimit + ".0 s";
        yield return new WaitForSeconds(delayTime);
        timeLimit -= 1f; //delaytime�� �پ���
        StartCoroutine(countTime(1f));
    }

    void UndoTimer()
    {
        cloak_Timer.enabled = false;
    }
}
