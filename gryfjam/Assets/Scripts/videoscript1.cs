using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class videoscript1 : MonoBehaviour
{

    VideoPlayer video;

    public GameObject[] musicObj;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Musicus");
        musicObj[0].GetComponent<AudioSource>().volume = 0;

    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Musicus");
        musicObj[0].GetComponent<AudioSource>().volume = 1;
        SceneManager.LoadScene(4);//the scene that you want to load after the video has ended.
        
    }
}
