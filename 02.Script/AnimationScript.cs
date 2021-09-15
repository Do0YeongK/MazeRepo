using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimator;
    [SerializeField]
    private GameObject player;

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
}
