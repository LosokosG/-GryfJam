using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newSceneLoad : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Next Level")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Respawn Point
        }
    }
        
}
