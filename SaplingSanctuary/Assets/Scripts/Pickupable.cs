using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    public string itemName; // Name of the item
    public Sprite itemIcon; // Icon of the item for inventory display

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Highlight(bool isHighlighted)
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = isHighlighted ? Color.yellow : Color.white;
            Debug.Log($"{itemName} Highlighted: {isHighlighted}");
        }
    }

    public string GetName()
    {
        return itemName;
    }

    public Sprite GetIcon()
    {
        return itemIcon;
    }
}