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

    //Slot저장하는 인벤토리 공간(slot의 부모가 될 아이)
    [SerializeField]
    private GameObject parentContent;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            //item 획득(충돌시 사라짐)
            other.gameObject.SetActive(false);
        }

        //item획득(인벤토리 저장)
        if (other.name == "Map")
        {
            Instantiate(mapSlot, parentContent.transform);  //Instantiate(GameObject, 부모);
        }
        if (other.name == "Hammer")
        {
            Instantiate(hammerSlot, parentContent.transform);   //Instantiate(GameObject, 부모);
        }
        if(other.name == "InvisibilityCloak")
        {
            Instantiate(cloakSlot, parentContent.transform);    //Instantiate(GameObject, 부모);
        }
    }
}
