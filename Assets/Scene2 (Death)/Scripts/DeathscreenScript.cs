using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DeathscreenScript : MonoBehaviour
{

    private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip restartVideo;
    [SerializeField] private GameObject canvas;

    bool activated = false;
    void Awake()
    {
        Cursor.visible = false;
    }


    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        AudioManager.instance.Play("CriticalError");
    }


    void Update()
    {
        if (Input.anyKey && !activated)
        {
            activated = true;
            ReloadGame();
        }
    }

    private void ReloadGame()
    {
        videoPlayer.url = Path.Combine(Application.streamingAssetsPath, "Reload.mp4");
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndReached;

        canvas.SetActive(false);
    }

    private void EndReached(VideoPlayer _)
    {
        SceneManager.LoadScene(0);
    }

}