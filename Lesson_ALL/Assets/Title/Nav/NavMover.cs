using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NavMover : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    //Update 사용하지 말기!!
    //실시간으로 따라가게 하려면 코루틴을 사용하면 됨
    private void Start()
    {
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(0.2f);

        while (true)
        {
            agent.destination = target.position;
            yield return delay;
        }
    }
}
