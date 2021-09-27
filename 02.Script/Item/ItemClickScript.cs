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

    //Hammer생성 개수(0일때 기본 Hammer가 SetActive되고, 1이상일 때  CloneHammer들이 생김)
    public int hammerNum = 0;

    //Slot저장하는 인벤토리 공간(slot의 부모가 될 아이)
    [SerializeField]
    private GameObject parentContent;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Map" || other.tag == "Cloak" || other.tag == "Hammer")   
        {
            //item 획득(충돌시 사라짐)
            other.gameObject.SetActive(false);
        }

        //item획득(인벤토리 저장)
        if (other.tag == "Map")    //지도는 1개니깐
        {
            mapSlot.SetActive(true);
        }
        if(other.tag == "Hammer" )
        {
            if(hammerNum == 0)  //맨 처음 먹은 hammer => slot활성화(clone이 생성될 때 slot이 같이 생김)
            {
                hammerSlot.SetActive(true);
                hammerNum++;
            }
            else
            {
                GameObject hammerSlotClone = Instantiate(hammerSlot, parentContent.transform);   //Instantiate(GameObject, 부모);
                hammerSlotClone.name = "hammerSlot_" + hammerNum;
                hammerSlotClone.SetActive(true);
                hammerNum++;
            }
        }
        if(other.tag == "Cloak")    //투명망토도 레어탬!!한개!!
        {
            cloakSlot.SetActive(true);
        }
    }
}
