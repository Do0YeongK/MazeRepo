using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel;
    bool activeInventory = false;   //true일 때 inventory창 열림

    [SerializeField]
    private GameObject joystick;    //joystick canvas

    [SerializeField]
    private GameObject enemy;   //적

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
            //enemy nav 멈춤
            enemy.GetComponent<NavMeshAgent>().isStopped = true;    //가속도로 밀림
            //enemy.GetComponent<NavMeshAgent>().enabled = false;   => enemyAI 스크립트에 오류생김(nav가 없어져서 Update문 돌다가 오류걸림)
        }
        else
        {
            joystick.SetActive(true);
            //enemy nav 다시 돌아가게
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            //enemy.GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    public void ClickItemCloseInventory()   //slot 누르면 inventory꺼짐
    {
        activeInventory = false;
        inventoryPanel.SetActive(activeInventory);
    }
}
