using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuCutscene : MonoBehaviour
{

    private VideoPlayer videoPlayer;

    private bool hasBooted;

    [SerializeField] private Texture2D cursor;
    [SerializeField] private Texture2D loadingCursor;

    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI infoText;



    private void Awake()
    {
        hasBooted = false;
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
    }

    private void Start()
    {
        videoPlayer.url = Path.Combine(Application.streamingAssetsPath, "startup.mp4");
        videoPlayer.Play();

        Cursor.visible = false;
        canvas.SetActive(false);
    }

    private void EndReached(VideoPlayer _)
    {
        if (!hasBooted)
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
            Cursor.visible = true;
            canvas.SetActive(true);
            StartCoroutine("FadeInText");
            hasBooted = true;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    private IEnumerator FadeInText()
    {
        infoText.alpha = 0.2f;
        yield return new WaitForSeconds(0.3f);
        infoText.alpha = 1f;
        yield break;
    }

    public void PlayLoadingVideo()
    {
        AudioManager.instance.Play("Click");
        canvas.SetActive(false);
        Cursor.SetCursor(loadingCursor, Vector2.zero, CursorMode.Auto);
        videoPlayer.url = Path.Combine(Application.streamingAssetsPath, "LoadGame.mp4");
        videoPlayer.Play();
    }

}