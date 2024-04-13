using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScript : MonoBehaviour
{

    private void Awake()
    {
        AudioManager.instance.Play("Popup");
    }

    public void ClosePopup()
    {
        AudioManager.instance.Play("Click");
        Destroy(gameObject);
    }

}