using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsRenderer : MonoBehaviour
{

    [SerializeField] private Sprite[] plantSprites;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void UpdateSprite(float currentWater)
    {
        if (currentWater > 80f)
            spriteRenderer.sprite = plantSprites[0];
        else if (currentWater > 50f)
            spriteRenderer.sprite = plantSprites[1];
        else
            spriteRenderer.sprite = plantSprites[2];
    }

}
