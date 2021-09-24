using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJoyStickMove : MonoBehaviour
{
    [Range(0,10)]
    public float speed = 5f; //플레이어 속도
    public GameObject player;   //플레이어
    private RectTransform rectTransform;

    private void Awake()
    {
        //가상 조이스틱 게임 오브젝트의 위치*****
        rectTransform = GetComponent<RectTransform>();  //lever변수와 Joystick의 Rect Transform을 가지고 있을 rectTansform변수 선언
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
        float Horizontal = rectTransform.anchoredPosition.x;    //조이스틱 중앙이(0,0), Horizontal =  조이스틱 x방향으로 이동한 값
        float Vertical = rectTransform.anchoredPosition.y;  //조이스틱 중앙이(0,0), Vertical =  조이스틱  y방향으로 이동한 값

        Vector3 position = new Vector3(Horizontal, 0, Vertical).normalized;
        player.transform.Translate(position * speed * Time.deltaTime, Space.Self);
    }
}


/*      //player 이동
        float Horizontal = rectTransform.anchoredPosition.x; //조이스틱 중앙이(0,0), Horizontal =  조이스틱 x방향으로 이동한 값
        float Vertical = rectTransform.anchoredPosition.y; //조이스틱 중앙이(0,0), Vertical =  조이스틱  y방향으로 이동한 값

        Vector3 Position = player.transform.position;

        Position.x += Horizontal * Time.deltaTime * speed;
        Position.z += Vertical * Time.deltaTime * speed;

        player.transform.position = Position;

        //player가 바라보는 방향으로 회전
        Vector3 dir = new Vector3(Horizontal, 0, Vertical);
        if (Horizontal != 0 && Vertical != 0)
        {
            player.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir*100f), Time.deltaTime * rotationSpeed);
        }*/
