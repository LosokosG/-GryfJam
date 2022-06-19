using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKiler : MonoBehaviour
{
    public Collider2D PlayerCol;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Death
        if (collision.collider.IsTouching(PlayerCol))
        {
            SceneManager.LoadScene(1);
        }

    }
}
