using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWaterUI : MonoBehaviour
{

    PlayerWaterHandler playerWater;
    private float maximumWater;

    private Image mask;

    private RectTransform arrow;
    private float maxPos = 140f;
    private float minPos = -160f;

    private Image wateringCan;



    private void Start()
    {
        playerWater = transform.parent.GetComponent<PlayerWaterHandler>();

        mask = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        arrow = transform.GetChild(1).GetComponent<RectTransform>();
        wateringCan = transform.GetChild(2).GetComponent<Image>();
    }



    private void Update()
    {
        UpdateMask();
        UpdateArrow();
    }

    private void UpdateMask()
    {
        float fillAmount = playerWater.GetCurrentWater() / playerWater.GetMaxWater();
        mask.fillAmount = fillAmount;
    }

    private void UpdateArrow()
    {
        float fractionalHeight = playerWater.GetCurrentWater() / playerWater.GetMaxWater();
        float actualHeight = maxPos * fractionalHeight + (1 - fractionalHeight) * minPos;
        arrow.anchoredPosition = new Vector2(arrow.anchoredPosition.x, actualHeight);
    }



    public void ToggleWateringCanOn(bool enabled)
    {
        wateringCan.gameObject.SetActive(enabled);
    }

}
