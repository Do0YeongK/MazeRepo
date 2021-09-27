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
    private Text cloak_Timer;   //제한시간 카운트 표시
    private float timeLimit = 6f; //제한시간

    public void MakeInvisibility()
    {
        cloakSlot.SetActive(false);
        player.SetActive(false);
        StartCoroutine(countTime(1f));  //1초마다 실행
        Invoke("UndoInvisibility", timeLimit);    //제한시간동안 안보임
        Invoke("UndoTimer", timeLimit);    //제한시간동안 안보임
    }

     void UndoInvisibility()
    {
        player.SetActive(true);
    }

    IEnumerator countTime(float delayTime)
    {
        cloak_Timer.text = "Timer : " + timeLimit + ".0 s";
        yield return new WaitForSeconds(delayTime);
        timeLimit -= 1f; //delaytime씩 줄어들게
        StartCoroutine(countTime(1f));
    }

    void UndoTimer()
    {
        cloak_Timer.enabled = false;
    }
}
