using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel;
    bool activeInventory = false;   //true�� �� inventoryâ ����

    [SerializeField]
    private GameObject joystick;    //joystick canvas

    [SerializeField]
    private GameObject enemy;   //��

    private void Start()
    {
        inventoryPanel.SetActive(activeInventory);
    }
    public void InventorySetActive()
    {
        activeInventory = !activeInventory;
        inventoryPanel.SetActive(activeInventory);
    }

    private void Update()
    {
        if (activeInventory == true)
        {
            joystick.SetActive(false);
            //enemy nav ����
            enemy.GetComponent<NavMeshAgent>().isStopped = true;    //���ӵ��� �и�
            //enemy.GetComponent<NavMeshAgent>().enabled = false;   => enemyAI ��ũ��Ʈ�� ��������(nav�� �������� Update�� ���ٰ� �����ɸ�)
        }
        else
        {
            joystick.SetActive(true);
            //enemy nav �ٽ� ���ư���
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            //enemy.GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    public void ClickItemCloseInventory()   //slot ������ inventory����
    {
        activeInventory = false;
        inventoryPanel.SetActive(activeInventory);
    }
}
