using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent nav;
    public GameObject target;   //Player(rigidbody)
    public GameObject targetBody;

    private void Start()
    {
        //3ÃÊ°£ nav¸¦ ²û
    }

    // Update is called once per frame
    void Update()
    {
        if(targetBody.activeInHierarchy == true)
        {
            nav.SetDestination(target.transform.position);
        }
    }

    void EnemyMove()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player");
        targetBody = GameObject.FindWithTag("PlayerBody");
    }
}
