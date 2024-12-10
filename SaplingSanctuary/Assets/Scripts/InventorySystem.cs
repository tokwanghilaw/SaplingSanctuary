using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    private List<string> items = new List<string>(); // List of items in the inventory

    // Add an item to the inventory
    public void AddItem(string itemName)
    {
        if (!items.Contains(itemName)) // Prevent adding duplicates
        {
            items.Add(itemName);
            Debug.Log($"{itemName} added to inventory.");
        }
    }

    // Add a seed to the inventory
    public void AddSeedToInventory()
    {
        AddItem("Seed"); // Adds "Seed" to the inventory
    }

    // Check if the player has a specific item
    public bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }

    // Check if the player has a seed
    public bool HasSeed()
    {
        return HasItem("Seed");  // Check for the "Seed" item
    }

    // Remove an item from the inventory
    public void RemoveItem(string itemName)
    {
        if (items.Contains(itemName))
        {
            items.Remove(itemName);
            Debug.Log($"{itemName} removed from inventory.");
        }
        else
        {
            Debug.LogWarning($"{itemName} not found in inventory.");
        }
    }
}