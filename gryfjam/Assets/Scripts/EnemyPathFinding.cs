using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathFinding : MonoBehaviour
{
    public NavMeshAgent agent;
    public Collider2D PlayerCollider;
    public Transform playerLocation;
    public Collider2D VisionRange;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (InRange())

            agent.SetDestination(playerLocation.position);
    }

    private bool InRange()
    {
        if (PlayerCollider.IsTouching(VisionRange))
        return true;
        else 
        return false; 
    }

}