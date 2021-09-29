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
    private GameObject player;  //player의 외관

    [SerializeField]
    private Text gameOver;  //winner 시장

    [SerializeField]
    private GameObject mainCamera;

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
            GameOver();
        }
        if(other.tag == "Exit")
        {
            //승리!!
            mainCamera.SetActive(false);    //메인 카메라 끔 => Launch 카메라가 켜짐
            gameOver.text = "Escape";
            Invoke("GameOver", 2.4f); //우주선 발사 애니메이션 후 retry버튼 나오게
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Wall")
        {
            this.transform.position = triggerPos;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }

    void GameOver()
    {
        Time.timeScale = 0;
        retryButton.SetActive(true);
    }
}
