using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickScript : MonoBehaviour
{
    [SerializeField]
    private GameObject mapSlot;
    [SerializeField]
    private GameObject hammerSlot;
    [SerializeField]
    private GameObject cloakSlot;

    //Slot�����ϴ� �κ��丮 ����(slot�� �θ� �� ����)
    [SerializeField]
    private GameObject parentContent;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            //item ȹ��(�浹�� �����)
            other.gameObject.SetActive(false);
        }

        //itemȹ��(�κ��丮 ����)
        if (other.name == "Map")
        {
            Instantiate(mapSlot, parentContent.transform);  //Instantiate(GameObject, �θ�);
        }
        if (other.name == "Hammer")
        {
            Instantiate(hammerSlot, parentContent.transform);   //Instantiate(GameObject, �θ�);
        }
        if(other.name == "InvisibilityCloak")
        {
            Instantiate(cloakSlot, parentContent.transform);    //Instantiate(GameObject, �θ�);
        }
    }
}
