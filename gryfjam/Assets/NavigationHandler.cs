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
    Collider2D GhostCol;
    public Collider2D PlayerCol;
    public Collider2D CherryCol;

    bool DestinationComplete;

    public Vector2 DestinationPosition;

    void Start()
    {
        GhostCol = GetComponent<Collider2D>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Death
        if (collision.collider.IsTouching(PlayerCol))
        {
            SceneManager.LoadScene(1);
        }

        Collider2D cherry = collision.gameObject.GetComponent<Collider2D>();
        

        //Cherry Collision
        if(cherry.Equals(CherryCol))
        {
            Debug.Log(cherry.name);
        }
    }
    private void SetDestinationPoint(Vector2 DestPoint)
    {
        GhostAgent.SetDestination(DestPoint);
    }
}
