using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent nav;

    bool run = false;   //nav �۵�����
    float waitTime = 4f; //���� player�� ������ �ð��� ��

    [SerializeField]
    private GameObject target;   //Player(rigidbody)
    [SerializeField]
    private GameObject targetBody;


    private void Start()
    {
        //waitTime���� nav�� ��
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

    void EnemyMove()    //waitTime �Ŀ� ����
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player");
        targetBody = GameObject.FindWithTag("PlayerBody");
        run = true;
    }
}
