using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject howToPlayButton;

    [SerializeField]
    private GameObject InstructionCanvas; //��뼳�� canvas

    private void Start()
    {
        StartCoroutine(Visibility(12f));
    }

    IEnumerator Visibility(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        startButton.SetActive(true);
        howToPlayButton.SetActive(true);
    }

    public void ClickStartButton()
    {
        //�� �̵�
        SceneManager.LoadScene("SpaceMaze");
    }

    public void ClickHowToPlay()
    {
        //��뼳�� ����
        InstructionCanvas.SetActive(true);
    }
}
