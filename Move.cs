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
    private bool stop;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        dirLine = gameObject.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        float px = 0, py = 0;
        px = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speedMove;
        py = Input.GetAxisRaw("Vertical") * Time.deltaTime * speedMove;
        if(px == 0 && py == 0)
        {
            if(stop)
            {
                stop = false;
                ThrowBall(gameObject.transform.position, pointer.position);
            }
                
            pos = gameObject.transform.position;
            

        }else stop = true;
        
        pos.x += px;
        pos.y += py;
        pointer.position = pos;
        dirLine.SetPosition(0, gameObject.transform.position);
        dirLine.SetPosition(1, pointer.position);

    }

    private void ThrowBall(Vector2 s, Vector2 e)
    {
        rb.AddForce((s - e).normalized * (s-e).magnitude * 300, ForceMode2D.Force);
    }
}
