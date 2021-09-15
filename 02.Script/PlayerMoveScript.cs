using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField]
    private Text text;  //GameOver text
    [SerializeField]
    private GameObject retryButton;

    //�浹ó�� : ���� �ε����� ������� �ʵ���
    Vector3 triggerPos;
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Wall")
        {
            triggerPos = this.transform.position;
        }
        if(other.tag == "Enemy")
        {
            text.text = "GameOver";
            Time.timeScale = 0;
            retryButton.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        this.transform.position = triggerPos;
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
