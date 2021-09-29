using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField]
    private Text text;  //GameOver text
    [SerializeField]
    private GameObject retryButton; //�ٽ��ϱ� ��ư ǥ��

    [SerializeField]
    private GameObject player;  //player�� �ܰ�

    [SerializeField]
    private Text gameOver;  //winner ����

    [SerializeField]
    private GameObject mainCamera;

    private void Start()
    {
        
    }
    //�浹ó�� : ���� �ε����� ������� �ʵ���
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
            //�¸�!!
            mainCamera.SetActive(false);    //���� ī�޶� �� => Launch ī�޶� ����
            gameOver.text = "Escape";
            Invoke("GameOver", 2.4f); //���ּ� �߻� �ִϸ��̼� �� retry��ư ������
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
