using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimator;

    private void Start()
    {
        StartCoroutine(cameraMoving(5f));
    }

    IEnumerator cameraMoving(float animation)
    {
        yield return new WaitForSeconds(animation);
        myAnimator.SetBool("CameraMoving", true);
    }
}
