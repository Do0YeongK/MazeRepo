using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimator;
    [SerializeField]
    private GameObject player;

    private void Start()
    {
        StartCoroutine(MoveDelay(3f));
    }

    private void Update()
    {
        myAnimator.SetBool("Attack", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            //АјАн
            myAnimator.SetBool("Attack", true);
        }
    }

    IEnumerator MoveDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        myAnimator.SetBool("Delay", true);
    }
}
