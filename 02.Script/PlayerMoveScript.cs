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
            Time.timeScale = 0;
            retryButton.SetActive(true);
        }
        if(other.tag == "Exit")
        {
            //�¸�!!
            gameOver.text = "Escape!!!!!";
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
}
