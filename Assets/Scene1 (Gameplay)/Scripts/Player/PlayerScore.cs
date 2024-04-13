using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public static class GlobalStore
{
    public static float score = 0f;
}

public class PlayerScore : MonoBehaviour
{
    TimeSpan time;
    private string scoreText;
    [SerializeField] private TextMeshProUGUI scoreDisplay;

    private void Start()
    {
        GlobalStore.score = 0f;
    }

    private void Update()
    {
        GlobalStore.score += Time.deltaTime;

        time = TimeSpan.FromSeconds(GlobalStore.score);

        scoreText = time.ToString(@"mm\:ss\:ff");

        scoreDisplay.SetText(scoreText);
    }

}
