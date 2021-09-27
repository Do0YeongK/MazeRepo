using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField]
    private GameObject map;

    //���� ������
    public void ShowMap()
    {
        Time.timeScale = 0;
        map.SetActive(true);
    }
    //���� ����
    public void CloseMap()
    {
        Time.timeScale = 1;
        map.SetActive(false);
    }
}
