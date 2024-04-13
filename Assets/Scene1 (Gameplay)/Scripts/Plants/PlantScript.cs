using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantScript : MonoBehaviour
{
    [SerializeField] private float maximumWater = 100f;
    private float currentWater;
    [SerializeField] private float drainRate = 1f;
    private PlantsWaterUI plantsWaterUI;
    [SerializeField] private PlantsRenderer plantsRenderer;
    [SerializeField] private PlayerWaterHandler playerWater;
    [SerializeField] private ToolHandler toolHandler;
    private Animator anim;
    [SerializeField] private DeathScript deathHandler;



    private void Awake()
    {
        currentWater = maximumWater;
        anim = gameObject.GetComponent<Animator>();
    }



    private void Start()
    {
        plantsWaterUI = transform.GetChild(0).GetComponent<PlantsWaterUI>();
    }



    private void Update()
    {
        plantsWaterUI.SetWaterLevel(maximumWater, currentWater);
        plantsRenderer.UpdateSprite(currentWater);
    }



    private void FixedUpdate()
    {
        ConsumeWater();
        if (currentWater <= 0)
            deathHandler.DoDeath();
    }

    private void ConsumeWater()
    {
        currentWater -= drainRate * Time.deltaTime;
    }



    public void DoClickAnimation()
    {
        anim.SetTrigger("click");
    }



    public void TryRefillWater()
    {
        if (toolHandler.GetTool() == Tools.wateringCan)
            RefillWater();
        else if (toolHandler.GetTool() == Tools.wateringCanEmpty)
        {
            anim.SetTrigger("click");    
            AudioManager.instance.Play("EmptyCan");
        }
        else
            AudioManager.instance.Play("WrongCursor");

    }

    private void RefillWater()
    {
        float waterInCan = playerWater.GetCurrentWater();
        float requiredWater = maximumWater - currentWater;

        if (waterInCan > requiredWater)
        {
            anim.SetTrigger("click");
            AudioManager.instance.Play("WaterPlant");
            playerWater.RemoveWater(requiredWater);
            currentWater = maximumWater;
        }
        else
        {
            anim.SetTrigger("click");
            AudioManager.instance.Play("WaterPlant");
            playerWater.RemoveWater(waterInCan);
            currentWater += waterInCan;
        }
    }

}
