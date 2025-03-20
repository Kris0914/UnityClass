using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private float dectectionRange = 20f;

    private NavMeshAgent agent;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distancePlayer =
            Vector3.Distance(transform.position, transform.position);
        if (distancePlayer < dectectionRange);
        {
            agent.SetDestination(player.position);
        }
    }
}
