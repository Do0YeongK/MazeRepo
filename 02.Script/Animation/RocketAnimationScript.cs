using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RocketAnimationScript : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimator;

    [SerializeField]
    private GameObject enemy;   //적

    bool activeInventory = false;   //true일 때 적이 못 움직임

    private void Update()
    {
        if(activeInventory == true)
        {
            //enemy 못움직이게
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activeInventory = true; //적이 못 움직임
            //로켓발사(탈출)
            myAnimator.SetBool("Launch", true);
        }
    }
}
