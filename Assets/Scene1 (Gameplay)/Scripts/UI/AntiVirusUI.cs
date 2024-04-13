using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AntiVirusUI : MonoBehaviour
{
    [SerializeField] private ToolHandler toolHandler;
    [SerializeField] private PlayerWaterUI playerWaterUI;

    public void ChangeCursorToBible()
    {
        AudioManager.instance.Play("HolySound");
        toolHandler.SetTool(Tools.holyAntiVirus);
        playerWaterUI.ToggleWateringCanOn(true);
    }

}
