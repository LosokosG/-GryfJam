using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreWalkable : MonoBehaviour
{
    public Collider2D PlayerCollider;
    public Collider2D WalkableSurface;
    void Start() { 
        
        Physics2D.IgnoreCollision(PlayerCollider, WalkableSurface);
    }


}
