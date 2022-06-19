using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyCrab : MonoBehaviour
{
    [SerializeField] private Transform person;
    [SerializeField] private float radius;
    [SerializeField] private float fireRate;
    [SerializeField] private float forceShoot;

    [SerializeField] private AnimationCurve curve;


    private float dist;
    private RaycastHit2D hit;   
    private Color raydebug = Color.red;
    
    [SerializeField] private float timerOfRate;
    [SerializeField] private TMP_Text scoreText;

    public AudioClip jump;
    public AudioClip idle;
    public AudioSource src;

    private void Awake()
    {
        person = GameObject.FindGameObjectWithTag("Player").transform;
        //scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
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
               
                StartCoroutine(JumpHit());
            }else raydebug = Color.red;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        Destroy(gameObject);
        Global.score += Random.Range(50, 150);
        //scoreText.text = $"SCORE [{Global.score}]";

    }
    private IEnumerator JumpHit()
    {
        Vector2 offset;
        Vector2 pos = person.position;
        float timer = 0;
        while(timer < 3.9)
        {   
            timer += Time.deltaTime;
            if(timer > 4)
            {
                timer = 0;
            }
            offset = curve.Evaluate(timer) * new Vector2(0,1);
            gameObject.transform.localScale = new Vector2(offset.y, offset.y);
            gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, pos, 0.005f);

            //src.clip = jump;//huj
            src.PlayOneShot(jump);

            yield return null;
        }
    }
}
