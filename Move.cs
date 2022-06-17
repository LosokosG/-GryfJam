using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    [SerializeField] private float speedMove;
    private LineRenderer dirLine;
    private Vector2 pos;
    private Rigidbody2D rb;
    private bool temp;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        dirLine = gameObject.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        float px = 0, pY = 0;
        if((px = Input.GetAxis("Horizontal") * Time.deltaTime * speedMove) == 0 && (pY = Input.GetAxis("Vertical") * Time.deltaTime * speedMove) == 0)
        {
            if(temp)
            {
                temp = false;
                ThrowBall(gameObject.transform.position, pointer.position);
            }
                
            pos = gameObject.transform.position;
            

        }else temp = true;
        
        pos.x += px;
        pos.y += pY;
        pointer.position = pos;
        dirLine.SetPosition(0, gameObject.transform.position);
        dirLine.SetPosition(1, pointer.position);

    }

    private void ThrowBall(Vector2 s, Vector2 e)
    {
        rb.AddForce((s - e).normalized * (s-e).magnitude * 300, ForceMode2D.Force);
    }
}
