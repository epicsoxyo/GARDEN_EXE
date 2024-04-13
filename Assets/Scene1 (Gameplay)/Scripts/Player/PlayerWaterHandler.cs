using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterHandler : MonoBehaviour
{

    private PlayerWaterUI playerWaterUI;
    [SerializeField] private ToolHandler toolHandler;

    [SerializeField] private float maximumWater = 100f;
    [SerializeField] private float currentWater;



    private void Awake()
    {
        currentWater = maximumWater;
    }



    private void Start()
    {
        playerWaterUI = transform.GetChild(0).GetComponent<PlayerWaterUI>();
    }



    public float GetMaxWater()
    {
        return maximumWater;
    }

    public float GetCurrentWater()
    {
        return currentWater;
    }

    public void RemoveWater(float waterToRemove)
    {
        currentWater -= waterToRemove;
        if (currentWater <= 0)
            toolHandler.SetTool(Tools.wateringCanEmpty);
    }

    public void RefillWater()
    {
        AudioManager.instance.Play("RefillCan");
        toolHandler.SetTool(Tools.wateringCan);
        currentWater = maximumWater;
        playerWaterUI.ToggleWateringCanOn(false);
    }

    public void SetCursorToCan()
    {
        if (currentWater <= 0) toolHandler.SetTool(Tools.wateringCanEmpty);
        else toolHandler.SetTool(Tools.wateringCan);
    }


}
