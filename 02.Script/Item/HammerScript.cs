using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    //Ŭ���� ���� ��
    [SerializeField]
    private GameObject targetWall;    //������ ��

    [SerializeField]
    private GameObject hammerSlot;

    bool stillDigging = false;

    private void Update()
    {
        if (stillDigging == true)
        {
            Digging();
        }
    }
    /// <summary>
    /// Ŭ���� ���� ������
    /// </summary>
    void Digging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if ((Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
                {
                    targetWall = hit.collider.gameObject;
                    if (targetWall.tag == "Wall")
                    {
                        Destroy(targetWall);
                    }                    //������ �ٸ��� ������ ���
                    else
                    {
                        Digging();
                    }
                }
            }
            stillDigging = false;
        }

        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Touch touch = Input.GetTouch(0); // ù��° ��ġ ��
                Vector2 touchPosition = touch.position; // ��ġ�� ��ġ

                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    targetWall = hit.collider.gameObject;
                    if(targetWall.tag == "Wall")
                    {
                        Destroy(targetWall);
                    }
                    //������ �ٸ��� ������ ���
                    else
                    {
                        Digging();
                    }
                }
            }
        }
    }

    public void OnclickHammer()
    {
        hammerSlot.SetActive(false);
        stillDigging = true;
    }
}

/* : wall �Ѹ��� �� �ٲٱ�
for (int i = 0; i<parentWall.transform.childCount; i++)
 {
    parentWall.transform.GetChild(i).GetComponent<MeshRenderer>().material = red;
 }
*/
