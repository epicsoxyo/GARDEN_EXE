using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSpawner : MonoBehaviour
{

    [SerializeField] private GameObject popup;
    [SerializeField] private Sprite[] popupSprites;

    [SerializeField] private float timeToFirstPopup;
    [SerializeField] private float minTimeToNextPopup;
    [SerializeField] private float startingMaxTimeToNextPopup;
    private float maxTimeToNextPopup;
    [SerializeField] private float lerpTime;
    private float elapsedTime = 0f;

    private bool isCountingDown;
    private float timer = 0f;



    private void Awake()
    {
        isCountingDown = true;
        timer = timeToFirstPopup;
        maxTimeToNextPopup = startingMaxTimeToNextPopup;
    }



    private void Update()
    {
        if (!isCountingDown)
        {
            CreateRandomPopup();
            timer = Random.Range(minTimeToNextPopup, maxTimeToNextPopup);
            isCountingDown = true;
        }
        else
        {
            DecrementTime();
            if (timer <= 0) isCountingDown = false;
        }

        DecrementTimeToNextPopup();

    }

    private void CreateRandomPopup()
    {
        GameObject newPopup = Instantiate(popup, transform);

        int spriteChoice = Random.Range(0, popupSprites.Length);
        newPopup.GetComponent<Image>().sprite = popupSprites[spriteChoice];
        newPopup.GetComponent<Image>().SetNativeSize();

        float x = Random.Range(-80f, 100f);
        float y = Random.Range(-340f, 200f);
        newPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);


    }

    private void DecrementTime()
    {
        timer -= Time.deltaTime;
    }

    private void DecrementTimeToNextPopup()
    {
        maxTimeToNextPopup = Mathf.Lerp(startingMaxTimeToNextPopup, minTimeToNextPopup, elapsedTime/lerpTime);
        elapsedTime += Time.deltaTime;
    }



}
