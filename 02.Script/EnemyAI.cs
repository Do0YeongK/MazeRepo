using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent nav;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target.activeSelf == true)  //Player가 보일때만(투명망토 사용시 감지 못함)
        {
            nav.SetDestination(target.transform.position);
        }   
    }
}
