using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;    
    private RectTransform rectTransform;

    [SerializeField, Range(10f, 150f)]
    private float leverRange = 100f;
    
    //조작기능 추가
    private Vector2 inputVector;
    private bool isInput;

    private void Awake()
    {
        //가상 조이스틱 게임 오브젝트의 위치*****
        rectTransform = GetComponent<RectTransform>();  //lever변수와 Joystick의 Rect Transform을 가지고 있을 rectTansform변수 선언
    }

        //OnBeginDrag & OnDrag에 들어 갈 코드(같음)
    public void ControlJoystickLever(PointerEventData eventData)
    {
        //lever 이동*****
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        //inputDir -= new Vector2(1920f, 0);  //조이스틱을 오른쪽에 둘 경우 모니터 x축 크기(여기서는 1920)만큼 빼줘야 함
        inputDir -= new Vector2(Screen.width,0);
        //lever 이동 제한(background안에서만 움직이게)
        var clampedDir = inputDir.magnitude < leverRange ?
            inputDir : inputDir.normalized * leverRange;    //본래위치 + 방향 * 거리

        //lever.anchoredPosition = inputDir - new Vector2(1920f, 0);  
        lever.anchoredPosition = clampedDir;
        inputVector = clampedDir / leverRange;  //  clampedDir는 해상도 기반 => 캐릭터 이동속도로 쓰기에 너무 값이 큼
    }
    //드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        isInput = true;
    }
    //드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        isInput = false;
    }
    //드래그 끝
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End");

        //원래 자리로 이동
        lever.anchoredPosition = Vector2.zero;
    }
}
