using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private GameObject hammer;
    [SerializeField]
    private GameObject invisibilityCloak;

    //Item�� �߰�(Item���� �θ�)
    [SerializeField]
    private GameObject parentItem;

    private void Start()
    {
        // ������ ���� ����
        Instantiate(map, new Vector3(Random.Range(-50f, 50f), 0.5f, Random.Range(-50f, 50f)), Quaternion.identity, parentItem.transform);
        Instantiate(hammer, new Vector3(Random.Range(-50f, 50f), 0.5f, Random.Range(-50f, 50f)), Quaternion.identity, parentItem.transform);
        Instantiate(invisibilityCloak, new Vector3(Random.Range(-50f, 50f), 0.5f, Random.Range(-50f, 50f)), Quaternion.identity, parentItem.transform);

        //�߰� ��ġ ������
        for (int i = 0; i < 3; ++i)
        {
            GameObject hammerClone 
                = Instantiate(hammer, new Vector3(Random.Range(-50f, 50f), 0.5f, Random.Range(-50f, 50f)), Quaternion.identity, parentItem.transform);
            hammerClone.name = "Hammer_" + (i+1);
        }
    }
}
