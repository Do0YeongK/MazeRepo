using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject targetWall;    //삭제할 벽
    public Material red;

    [SerializeField]
    private GameObject hammerSlot;

    bool stillDigging = false;

    private void Update()
    {
        if(stillDigging == true)
        {
            Digging();
        }
    }
    /// <summary>
    /// 클릭한 벽을 삭제함
    /// </summary>
    void Digging()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if ((Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
                {
                    targetWall = hit.collider.gameObject;
                    GameObject parentWall = targetWall.transform.parent.gameObject;
                    Destroy(parentWall);
                }
            }
            stillDigging = false;
        }

        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Touch touch = Input.GetTouch(0); // 첫번째 터치 값
                Vector2 touchPosition = touch.position; // 터치한 위치

                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    targetWall = hit.collider.gameObject;
                    GameObject parentWall = targetWall.transform.parent.gameObject; //wall_cell의 부모인 Wall한면을 받음
                    Destroy(parentWall);    //벽 한면 삭제
                }
            }
        }
    }

    public void OnclickHammer()
    {
        stillDigging = true;
    }
}

/* : wall 한면의 색 바꾸기
for (int i = 0; i<parentWall.transform.childCount; i++)
 {
    parentWall.transform.GetChild(i).GetComponent<MeshRenderer>().material = red;
 }
*/