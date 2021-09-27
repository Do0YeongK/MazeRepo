using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;

    private void Start()
    {
        StartCoroutine(Visibility(12f));
    }

    IEnumerator Visibility(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        startButton.SetActive(true);
    }

    public void ClickStartButton()
    {
        //æ¿ ¿Ãµø
    }
}
