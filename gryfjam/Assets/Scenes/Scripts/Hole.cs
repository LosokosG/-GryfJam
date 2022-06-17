using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    bool isTouching;
    


    void Update()
    {


        if (isTouching)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }

}
