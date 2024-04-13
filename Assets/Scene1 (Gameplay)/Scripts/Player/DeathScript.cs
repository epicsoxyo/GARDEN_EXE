using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{

    private VideoPlayer videoPlayer;
    private Renderer rend;



    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = Path.Combine(Application.streamingAssetsPath, "DeathScreen.mp4");
        videoPlayer.Prepare ();
        videoPlayer.loopPointReached += EndReached;

        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    public void DoDeath()
    {
        rend.enabled = true;
        videoPlayer.Play();
    }

    private void EndReached(VideoPlayer _)
    {
        SceneManager.LoadScene(2);
    }

}
