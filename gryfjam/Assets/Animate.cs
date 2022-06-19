using UnityEngine;
using System.Collections;

public class Animate : MonoBehaviour
{
    float minValue = -10f;
    float maxValue = 10f;
    void Update()
    {
        if(transform.position.y <=maxValue)
        transform.position = Vector2.up * Time.deltaTime;
        if(transform.position.y>=minValue)
        transform.position = -Vector2.up * Time.deltaTime;
    }
}

