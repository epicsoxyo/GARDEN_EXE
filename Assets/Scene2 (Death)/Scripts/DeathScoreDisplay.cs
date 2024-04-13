using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DeathScoreDisplay : MonoBehaviour
{

    TimeSpan time;
    private string scoreText;
    private TextMeshProUGUI scoreDisplay;

    private void Awake()
    {
        scoreDisplay = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        time = TimeSpan.FromSeconds(GlobalStore.score);

        scoreText = time.ToString(@"mmssff");
        scoreText = scoreText.Insert(6, "MS");
        scoreText = scoreText.Insert(4, "S : ");
        scoreText = scoreText.Insert(2, "M : ");

        scoreDisplay.SetText(scoreText);
    }

}
