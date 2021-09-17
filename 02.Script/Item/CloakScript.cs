using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject cloakSlot;

    public void MakeInvisibility()
    {
        cloakSlot.SetActive(false);
        player.SetActive(false);
        Invoke("UndoInvisibility", 6f);    //6초간 안보임
    }

    public void UndoInvisibility()
    {
        player.SetActive(true);
    }
}
