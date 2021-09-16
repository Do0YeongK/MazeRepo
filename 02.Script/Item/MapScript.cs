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
        map.SetActive(true);
    }
    //���� ����
    public void CloseMap()
    {
        map.SetActive(false);
    }
}
