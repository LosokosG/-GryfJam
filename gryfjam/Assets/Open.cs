using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    void Update()
    {
        

        int Counter = CherryScript.CherryCount;
        if (CherryScript.CherryCount == 10)
        {
            Counter = 0;
            Destroy(gameObject);
        }
       Debug.Log(Counter);
    }
}
