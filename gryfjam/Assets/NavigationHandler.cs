using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NavigationHandler : MonoBehaviour
{
    NavMeshAgent GhostAgent;
    public List<GameObject> Kids = new List<GameObject>();
    public List<GameObject> Cherrys = new List<GameObject>();
    GameObject currentPoint;
    int index;
    public Collider2D ThisGhostCol;

    public Collider2D PlayerCol;

    float countdown = 3;

    public Vector2 DestinationPosition;

    void Start()
    {
        Collider2D ThisGhostCol = gameObject.GetComponent<Collider2D>();

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("DestinationPoint"))
        {
            Kids.Add(fooObj);
        }
        GhostAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (GhostAgent.pathPending) isStuck();


        if (!GhostAgent.hasPath || isStuck())
        {
            index = Random.Range(0, Kids.Count);
            currentPoint = Kids[index];
            DestinationPosition = new Vector2(currentPoint.gameObject.transform.position.x, currentPoint.gameObject.transform.position.y);
            SetDestinationPoint(DestinationPosition);
        }


    }

    private bool isStuck()
    {
        countdown -= Time.deltaTime;
        if (countdown == 0)
        {
            countdown = 0;
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Death
        if (collision.collider.IsTouching(PlayerCol))
        {
            SceneManager.LoadScene(4);
        }

    }
    private void SetDestinationPoint(Vector2 DestPoint)
    {
        GhostAgent.SetDestination(DestPoint);
    }
}
