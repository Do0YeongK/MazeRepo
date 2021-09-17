using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool activeInventory = false;

    private void Start()
    {
        inventoryPanel.SetActive(activeInventory);
    }
    public void InventorySetActive()
    {
        activeInventory = !activeInventory;
        inventoryPanel.SetActive(activeInventory);
    }

    public void ClickItemCloseInventory()   //slot ´©¸£¸é inventory²¨Áü
    {
        activeInventory = false;
        inventoryPanel.SetActive(activeInventory);
    }
}
