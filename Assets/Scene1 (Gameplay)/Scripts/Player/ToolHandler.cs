using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tools
{
    wateringCan,
    wateringCanEmpty,
    holyAntiVirus,
};

public class ToolHandler : MonoBehaviour
{

    [SerializeField] private Texture2D[] cursors = new Texture2D[3];

    private Tools currentTool = Tools.wateringCan;



    private void Awake()
    {
        Cursor.SetCursor(cursors[0], Vector2.zero, CursorMode.Auto);
    }



    public Tools GetTool()
    {
        return currentTool;
    }

    public void SetTool(Tools newTool)
    {
        currentTool = newTool;
        int imageIndex = (int)currentTool;
        Cursor.SetCursor(cursors[imageIndex], Vector2.zero, CursorMode.Auto);
    }

}
