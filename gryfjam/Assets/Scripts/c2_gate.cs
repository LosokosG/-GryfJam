using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class c2_gate : MonoBehaviour
{

    public GameObject parts;
    private m2_parts parts_script;

    // Start is called before the first frame update
    void Start()
    {
        parts_script = parts.GetComponent<m2_parts>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            if (parts_script.partsTaken == true)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
