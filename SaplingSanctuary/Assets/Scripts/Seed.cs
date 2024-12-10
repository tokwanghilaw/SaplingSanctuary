using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public Sprite[] growthStages; // Sprites for each growth stage
    public float growthTime = 5f; // Time between growth stages
    public bool isPlanted = false; // Flag to check if the seed is planted

    private SpriteRenderer spriteRenderer;
    private int currentStage = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (growthStages.Length > 0)
        {
            spriteRenderer.sprite = growthStages[currentStage];
        }
    }

    void Update()
    {
        // If the seed is planted, start growing
        if (isPlanted)
        {
            StartCoroutine(Grow());
        }
    }

    public void StartGrowing()
    {
        // Trigger growth process
        isPlanted = true;
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
