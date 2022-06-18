using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestrSelector : MonoBehaviour
{
    public List<GameObject> Kids = new List<GameObject>();
    void Start()
    {
   
    }
    void Update()
     {    
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("DestinationPoint"))
        {
            Kids.Add(fooObj);
        }
     }
    
}
