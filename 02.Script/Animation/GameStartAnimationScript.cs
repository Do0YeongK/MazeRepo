using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartAnimationScript : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimator;

    private void Start()
    {
        myAnimator.SetBool("GameStartMoving", true);
        StartCoroutine(StartcameraMoving(3f));
    }

    IEnumerator StartcameraMoving(float animation)
    {
        yield return new WaitForSeconds(animation);
        myAnimator.SetBool("GameStartMoving", false);
    }
}
