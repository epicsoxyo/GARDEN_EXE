using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class RAMScript : MonoBehaviour
{
    [SerializeField] private float timeToStart = 20f;
    [SerializeField] private float timeToMaxIntensity = 1800f;
    private float timeElapsed = 0f;
    private DigitalGlitch digitalGlitch;

    private void Awake()
    {
        timeElapsed = 0;
        digitalGlitch = GetComponent<DigitalGlitch>();
        timeToMaxIntensity += timeToStart;
    }

    void Update()
    {
        if (timeElapsed > timeToStart)
            digitalGlitch.intensity = Mathf.Lerp(0f, 1f, timeElapsed/timeToMaxIntensity);

        timeElapsed += Time.deltaTime;
    }

}
