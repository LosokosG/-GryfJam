using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPer : MonoBehaviour
{
    [SerializeField] private Transform person, muzzle;
    [SerializeField] private GameObject gun;

    [SerializeField] private float fireRate;
    [SerializeField] private float forceShoot;
    
    [SerializeField] private float timerOfRate;
    [SerializeField] private GameObject bulletPrefabe;

    public float huj = -1.5f;

    private void Awake()
    {
        person = GameObject.FindGameObjectWithTag("Player").transform;
        muzzle = GameObject.FindGameObjectWithTag("Muzzle").transform;
        gun = GameObject.FindGameObjectWithTag("Gun");
        StartCoroutine(Shooting());
    }
    // private void Update()
    // {
    //     timerOfRate += Time.deltaTime;

    //     if(timerOfRate > fireRate)
    //     {
    //         timerOfRate = 0;    
    //         raydebug = Color.grey;
    //         gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.right, hit.normal);
    //         Instantiate(bulletPrefabe, gameObject.transform.position, Quaternion.identity).gameObject.GetComponent<Rigidbody2D>().AddForce((person.position - gameObject.transform.position).normalized * forceShoot, ForceMode2D.Impulse);
    
    //     }
        
    // }
    private IEnumerator Shooting()
    {
        float time = 0;
        while(true)
        {
            time += Time.deltaTime;
            timerOfRate += Time.deltaTime;
            gun.transform.rotation = Quaternion.AxisAngle(Vector3.forward, Mathf.Sin(time)+huj);
            if(timerOfRate > fireRate)
            {
                Instantiate(bulletPrefabe, muzzle.transform.position, Quaternion.identity).gameObject.GetComponent<Rigidbody2D>().AddForce((muzzle.transform.position-gun.transform.position).normalized * forceShoot, ForceMode2D.Impulse);
                timerOfRate = 0;
            }
            //Destroy(gameObject, 5f);
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
