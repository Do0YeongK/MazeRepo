using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField]
    private GameObject map;

    [SerializeField]
    private GameObject inventory;

    //Áöµµ º¸¿©ÁÜ
    public void ShowMap()
    {
        inventory.SetActive(false);
        Time.timeScale = 0;
        map.SetActive(true);
    }
    //Áöµµ ´ÝÀ½
    public void CloseMap()
    {
        Time.timeScale = 1;
        map.SetActive(false);
        inventory.SetActive(true);
    }
}
