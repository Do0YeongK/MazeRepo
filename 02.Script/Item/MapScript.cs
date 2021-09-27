using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField]
    private GameObject map;

    //Áöµµ º¸¿©ÁÜ
    public void ShowMap()
    {
        Time.timeScale = 0;
        map.SetActive(true);
    }
    //Áöµµ ´ÝÀ½
    public void CloseMap()
    {
        Time.timeScale = 1;
        map.SetActive(false);
    }
}
