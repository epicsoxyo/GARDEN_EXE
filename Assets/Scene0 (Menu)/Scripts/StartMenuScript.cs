using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{

    private Image startMenu;
    private bool isEnabled = false;

    private void Start()
    {
        startMenu = transform.GetChild(0).GetComponent<Image>();
        SetAlpha(0f);
    }

    public void ToggleWindow()
    {
        if (isEnabled)
            ToggleWindowOFF();
        else
            StartCoroutine("ToggleWindowON");
    }

    private IEnumerator ToggleWindowON()
    {
        isEnabled = true;

        SetAlpha(0.5f);

        yield return new WaitForSeconds(0.5f);

        if (isEnabled)
            SetAlpha(1f);
    
        yield break;
    }

    private void ToggleWindowOFF()
    {
        isEnabled = false;

        SetAlpha(0f);
    }

    private void SetAlpha(float newAlpha)
    {
        Color newColor = startMenu.color;
        newColor.a = newAlpha;
        startMenu.color = newColor;
    }

}
