using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent nav;

    bool run = false;   //nav 작동여부
    float waitTime = 4f; //적이 player가 도망갈 시간을 줌

    [SerializeField]
    private GameObject target;   //Player(rigidbody)
    [SerializeField]
    private GameObject targetBody;


    private void Start()
    {
        //waitTime동안 nav를 끔
        Invoke("EnemyMove", waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetBody == null || nav == false)
        { }
        else if (targetBody.activeInHierarchy == true && run == true)
        {
            nav.SetDestination(target.transform.position);
        }

    }

    void EnemyMove()    //waitTime 후에 실행
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player");
        targetBody = GameObject.FindWithTag("PlayerBody");
        run = true;
    }
}
