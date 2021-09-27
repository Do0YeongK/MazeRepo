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

    //Hammer���� ����(0�϶� �⺻ Hammer�� SetActive�ǰ�, 1�̻��� ��  CloneHammer���� ����)
    public int hammerNum = 0;

    //Slot�����ϴ� �κ��丮 ����(slot�� �θ� �� ����)
    [SerializeField]
    private GameObject parentContent;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Map" || other.tag == "Cloak" || other.tag == "Hammer")   
        {
            //item ȹ��(�浹�� �����)
            other.gameObject.SetActive(false);
        }

        //itemȹ��(�κ��丮 ����)
        if (other.tag == "Map")    //������ 1���ϱ�
        {
            mapSlot.SetActive(true);
        }
        if(other.tag == "Hammer" )
        {
            if(hammerNum == 0)  //�� ó�� ���� hammer => slotȰ��ȭ(clone�� ������ �� slot�� ���� ����)
            {
                hammerSlot.SetActive(true);
                hammerNum++;
            }
            else
            {
                GameObject hammerSlotClone = Instantiate(hammerSlot, parentContent.transform);   //Instantiate(GameObject, �θ�);
                hammerSlotClone.name = "hammerSlot_" + hammerNum;
                hammerSlotClone.SetActive(true);
                hammerNum++;
            }
        }
        if(other.tag == "Cloak")    //������䵵 ������!!�Ѱ�!!
        {
            cloakSlot.SetActive(true);
        }
    }
}
