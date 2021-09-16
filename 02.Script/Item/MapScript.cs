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
        map.SetActive(true);
    }
    //Áöµµ ´ÝÀ½
    public void CloseMap()
    {
        map.SetActive(false);
    }
}
