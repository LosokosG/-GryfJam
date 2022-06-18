using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private void Awake()
    {
        //scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
    }
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        Global.score += Random.Range(10, 50);
        //scoreText.text = $"SCORE [{Global.score}]";
        Destroy(gameObject);


    }
}