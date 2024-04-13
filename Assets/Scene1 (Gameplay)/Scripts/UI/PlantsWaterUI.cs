using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantsWaterUI : MonoBehaviour
{
    private int maximumDots;
    private int currentDots;
    private List<Image> dotSprites;



    private void Start()
    {
        maximumDots = transform.childCount;

        GetDotsToTransform();

        InitialiseDots();
    }

    private void GetDotsToTransform()
    {
        dotSprites = new List<Image>();

        for (int i = 0; i < maximumDots; i++)
            dotSprites.Add(transform.GetChild(i).GetComponent<Image>());
    }

    private void InitialiseDots()
    {
        for (int i = 0; i < maximumDots; i++)
            dotSprites[i].enabled = true;
    }



    public void SetWaterLevel(float maximumWater, float currentWater)
    {
        if (currentWater > 0f)
        {
            float waterPerDot = maximumWater / maximumDots;
            currentDots = (int)Mathf.Round(currentWater / waterPerDot);
        }
        else currentDots = 0;
    }



    private void Update()
    {
        UpdateDots();
    }

    private void UpdateDots()
    {
        for (int i = 0; i < currentDots; i++)
            dotSprites[i].enabled = true;

        for (int i = currentDots; i < maximumDots; i++)
            dotSprites[i].enabled = false;
    }

}
