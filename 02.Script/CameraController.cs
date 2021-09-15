using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    Vector3 firstPos;
    Vector3 secondPos;

    float xAngle = 15f;   //�÷��̾� xAngle
    float yAngle = 0;   //�÷��̾� yAngle
    float xAngleTemp;   //ó�� xAngle��
    //float yAngleTemp;   //ó�� yAngle��  :   y�ε� ȸ���ϰ� �� �� ���

    float halfScreenWidth;  //ȭ�� 2/3�� ��ġ�ϸ� ī�޶� ȸ��

    void Start()
    {
        halfScreenWidth = ( Screen.width *2 )/ 3;
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);  //ó�� player angle setting
    }

    private void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (Input.touchCount > 0 && touch.position.x < this.halfScreenWidth)
        {
            if (touch.phase == TouchPhase.Began)
            {
                firstPos = touch.position;
                xAngleTemp = xAngle;
                //yAngleTemp = yAngle;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                secondPos = touch.position;
                xAngle = xAngleTemp + (secondPos.x - firstPos.x) * 180 / Screen.width;
                //yAngle = yAngleTemp + (secondPos.y - firstPos.y) * 90 / Screen.heightx;
                player.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0f);
            }
        }
    }
}
