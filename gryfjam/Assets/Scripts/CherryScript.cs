using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CherryScript : MonoBehaviour
{
    public Collider2D Cherry;
    public Collider2D Player;
    public SpriteRenderer spriteRenderer;
    public ParticleSystem CollectAnim;
    

    public Sprite foundCherry;

    int CherryCount = 0;
    void Update()
    {
        if (CherryCount == 4) { SceneManager.LoadScene(2); Debug.Log("Next"); }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        CherryCount += 1;
        Debug.Log(CherryCount);
        spriteRenderer.sprite = foundCherry;
        Physics2D.IgnoreCollision(Player, Cherry);
        CollectAnim.Play(Player);
    }
}
