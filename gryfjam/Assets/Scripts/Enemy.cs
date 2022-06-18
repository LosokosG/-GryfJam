using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform person;

    [SerializeField] private float radius;
    [SerializeField] private float fireRate;
    [SerializeField] private float forceShoot;
    [SerializeField] private GameObject bulletPrefabe;
    private float dist;
    private RaycastHit2D hit;   
    private Color raydebug = Color.red;
    
    [SerializeField] private float timerOfRate;
    private void Awake()
    {
        person = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        dist = Vector2.Distance(gameObject.transform.position, person.position);
        if(dist > radius) return;
        hit = Physics2D.Raycast(gameObject.transform.position, (person.position - gameObject.transform.position).normalized * dist);
        Debug.DrawRay(gameObject.transform.position, (person.position - gameObject.transform.position).normalized * dist, raydebug);
        timerOfRate += Time.deltaTime;
        if(hit.collider != null )
        {
            if(hit.collider.tag == "Player" && timerOfRate > fireRate)
            {
                timerOfRate = 0;    
                raydebug = Color.grey;
                gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.right, hit.normal);
                Instantiate(bulletPrefabe, gameObject.transform.position, Quaternion.identity).gameObject.GetComponent<Rigidbody2D>().AddForce((person.position - gameObject.transform.position).normalized * forceShoot, ForceMode2D.Impulse);
    
            }else raydebug = Color.red;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Bullet")
        {
            gameObject.transform.position = Vector2.zero;
        }
    }

}
