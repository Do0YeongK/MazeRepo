using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAnimationScript : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //���Ϲ߻�(Ż��)
            myAnimator.SetBool("Launch", true);
        }
    }
}
