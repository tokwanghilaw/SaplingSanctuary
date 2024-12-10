using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGrowth : MonoBehaviour
{
    public Sprite[] growthStages; // Sprites for the different growth stages
    public float growthTime = 5f; // Time between growth stages

    private SpriteRenderer spriteRenderer;
    private int currentStage = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (growthStages.Length > 0)
        {
            spriteRenderer.sprite = growthStages[currentStage];
            StartCoroutine(Grow());
        }
    }

    IEnumerator Grow()
    {
        while (currentStage < growthStages.Length - 1)
        {
            yield return new WaitForSeconds(growthTime);
            currentStage++;
            spriteRenderer.sprite = growthStages[currentStage];
        }
    }
}
