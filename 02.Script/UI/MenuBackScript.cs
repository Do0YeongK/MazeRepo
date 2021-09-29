using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackScript : MonoBehaviour
{
    [SerializeField]
    private GameObject menuBackButton;

    [SerializeField]
    private GameObject nextMenuButton;

    [SerializeField]
    private GameObject backMenuButton;

    [SerializeField]
    private GameObject howToPlayImage_2;    //사용설명서 다음장

    public void MenuBackButton()
    {
        menuBackButton.transform.parent.gameObject.SetActive(false);
    }

    public void NextMenu()
    {
        nextMenuButton.SetActive(false);
        howToPlayImage_2.SetActive(true);
        backMenuButton.SetActive(true);
    }

    public void BackMenu()
    {
        backMenuButton.SetActive(false);
        howToPlayImage_2.SetActive(false);
        nextMenuButton.SetActive(true);
    }
}
