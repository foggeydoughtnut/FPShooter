using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float distanceToTrack;

    public GameObject player;
    private NavMeshAgent navMeshAgent;
    private Vector3 startingPosition;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        startingPosition = transform.position;
    }
    private void FixedUpdate()
    {
        
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < distanceToTrack)
        {
            navMeshAgent.destination = player.transform.position;
        } else
        {
            navMeshAgent.destination = startingPosition;
        }
       
    }
}
