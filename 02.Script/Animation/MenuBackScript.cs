using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackScript : MonoBehaviour
{
    [SerializeField]
    private GameObject menuBackButton;

    public void MenuBackButton()
    {
        menuBackButton.transform.parent.gameObject.SetActive(false);
    }
}
