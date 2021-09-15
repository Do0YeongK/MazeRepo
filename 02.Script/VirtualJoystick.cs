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
    
    //���۱�� �߰�
    private Vector2 inputVector;
    private bool isInput;

    private void Awake()
    {
        //���� ���̽�ƽ ���� ������Ʈ�� ��ġ*****
        rectTransform = GetComponent<RectTransform>();  //lever������ Joystick�� Rect Transform�� ������ ���� rectTansform���� ����
    }

        //OnBeginDrag & OnDrag�� ��� �� �ڵ�(����)
    public void ControlJoystickLever(PointerEventData eventData)
    {
        //lever �̵�*****
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        //inputDir -= new Vector2(1920f, 0);  //���̽�ƽ�� �����ʿ� �� ��� ����� x�� ũ��(���⼭�� 1920)��ŭ ����� ��
        inputDir -= new Vector2(Screen.width,0);
        //lever �̵� ����(background�ȿ����� �����̰�)
        var clampedDir = inputDir.magnitude < leverRange ?
            inputDir : inputDir.normalized * leverRange;    //������ġ + ���� * �Ÿ�

        //lever.anchoredPosition = inputDir - new Vector2(1920f, 0);  
        lever.anchoredPosition = clampedDir;
        inputVector = clampedDir / leverRange;  //  clampedDir�� �ػ� ��� => ĳ���� �̵��ӵ��� ���⿡ �ʹ� ���� ŭ
    }
    //�巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        isInput = true;
    }
    //�巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        isInput = false;
    }
    //�巡�� ��
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End");

        //���� �ڸ��� �̵�
        lever.anchoredPosition = Vector2.zero;
    }
}
