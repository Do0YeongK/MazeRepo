using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField]
    private Text text;  //GameOver text
    [SerializeField]
    private GameObject retryButton; //다시하기 버튼 표시
    [SerializeField]
    private GameObject startWall;   //시작지점 밟으면 벽 생김

    [SerializeField]
    private GameObject player;  //player의 외관

    private void Start()
    {
        
    }
    //충돌처리 : 벽에 부딪혀도 통과하지 않도록
    Vector3 triggerPos;
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Wall")
        {
            triggerPos = this.transform.position;
        }
        if(other.tag == "Enemy" && player.activeSelf == true)
        {
            text.text = "GameOver";
            Time.timeScale = 0;
            retryButton.SetActive(true);
        }
        if(other.tag == "StartFloor")
        {
            //3초뒤에 벽이 생김
            Invoke("MakeStartWall", 3f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("TriggerWall");
        if(other.tag == "Wall")
        {
            this.transform.position = triggerPos;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    void MakeStartWall()    //start벽 생성
    {
        startWall.SetActive(true);
    }
}
