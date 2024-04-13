using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RainbowText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private float colourShift = 0f;
    [SerializeField] private float speed = 0.1f;


    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.fontMaterial.SetTextureOffset("_FaceTex", new Vector2(0, colourShift));

        colourShift += speed * Time.deltaTime;
        if (colourShift > 1f)
            colourShift = 0f;
    }
}
