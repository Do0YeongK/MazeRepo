using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJoyStickMove : MonoBehaviour
{
    [Range(0,10)]
    public float speed = 5f; //�÷��̾� �ӵ�
    public GameObject player;   //�÷��̾�
    private RectTransform rectTransform;

    private void Awake()
    {
        //���� ���̽�ƽ ���� ������Ʈ�� ��ġ*****
        rectTransform = GetComponent<RectTransform>();  //lever������ Joystick�� Rect Transform�� ������ ���� rectTansform���� ����
    }
    private void Start()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }
    private void Update()
    {
        float Horizontal = rectTransform.anchoredPosition.x;    //���̽�ƽ �߾���(0,0), Horizontal =  ���̽�ƽ x�������� �̵��� ��
        float Vertical = rectTransform.anchoredPosition.y;  //���̽�ƽ �߾���(0,0), Vertical =  ���̽�ƽ  y�������� �̵��� ��

        Vector3 position = new Vector3(Horizontal, 0, Vertical).normalized;
        player.transform.Translate(position * speed * Time.deltaTime, Space.Self);
    }
}


/*      //player �̵�
        float Horizontal = rectTransform.anchoredPosition.x; //���̽�ƽ �߾���(0,0), Horizontal =  ���̽�ƽ x�������� �̵��� ��
        float Vertical = rectTransform.anchoredPosition.y; //���̽�ƽ �߾���(0,0), Vertical =  ���̽�ƽ  y�������� �̵��� ��

        Vector3 Position = player.transform.position;

        Position.x += Horizontal * Time.deltaTime * speed;
        Position.z += Vertical * Time.deltaTime * speed;

        player.transform.position = Position;

        //player�� �ٶ󺸴� �������� ȸ��
        Vector3 dir = new Vector3(Horizontal, 0, Vertical);
        if (Horizontal != 0 && Vertical != 0)
        {
            player.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir*100f), Time.deltaTime * rotationSpeed);
        }*/
