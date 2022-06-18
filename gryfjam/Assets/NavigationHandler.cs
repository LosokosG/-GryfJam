using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NavigationHandler : MonoBehaviour
{
    NavMeshAgent GhostAgent;
    public List<GameObject> Kids = new List<GameObject>();
    GameObject currentPoint;
    int index;

    bool DestinationComplete;

    public Vector2 DestinationPosition;

    void Start()
    {
        GhostAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("DestinationPoint"))
        {
            Kids.Add(fooObj);
        }


        if (!GhostAgent.hasPath)
        {

            index = Random.Range(0, Kids.Count);
            currentPoint = Kids[index];
            DestinationPosition = new Vector2(currentPoint.gameObject.transform.position.x, currentPoint.gameObject.transform.position.y);
            SetDestinationPoint(DestinationPosition);
        }
    }


    private void SetDestinationPoint(Vector2 DestPoint)
    {
        GhostAgent.SetDestination(DestPoint);
    }
}
