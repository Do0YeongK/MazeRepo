using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RocketAnimationScript : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimator;

    [SerializeField]
    private GameObject enemy;   //��

    bool activeInventory = false;   //true�� �� ���� �� ������

    private void Update()
    {
        if(activeInventory == true)
        {
            //enemy �������̰�
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activeInventory = true; //���� �� ������
            //���Ϲ߻�(Ż��)
            myAnimator.SetBool("Launch", true);
        }
    }
}
