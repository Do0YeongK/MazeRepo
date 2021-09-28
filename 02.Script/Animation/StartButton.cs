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
    private GameObject InstructionCanvas; //사용설명서 canvas

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
        //씬 이동
        SceneManager.LoadScene("SpaceMaze");
    }

    public void ClickHowToPlay()
    {
        //사용설명 나옴
        InstructionCanvas.SetActive(true);
    }
}
