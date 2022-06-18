using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m2_parts : MonoBehaviour
{
    public SpriteRenderer gate;
    public bool partsTaken;
    public Sprite huj;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            Destroy(gameObject);
            partsTaken = true;
            gate.sprite = huj;
        }        

    }
}
