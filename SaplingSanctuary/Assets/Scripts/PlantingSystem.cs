using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingSystem : MonoBehaviour
{
    public KeyCode plantKey = KeyCode.F; // Key to plant the seed
    public float plantingRange = 2f; // Range to detect planting areas
    public InventorySystem inventorySystem; // Reference to the InventorySystem
    public LayerMask plantingLayer; // Layer for valid planting areas

    private GameObject plantingIndicator;
    private bool canPlant = false;
    private Collider2D plantingAreaCollider;
    public GameObject seedPrefab;

    void Start()
    {
        // Create an indicator above the player
        plantingIndicator = new GameObject("PlantingIndicator");
        TextMesh textMesh = plantingIndicator.AddComponent<TextMesh>();
        textMesh.text = "Plant seed";
        textMesh.fontSize = 20;
        textMesh.color = Color.green;
        plantingIndicator.SetActive(false);
    }

    void Update()
    {
        // Detect plantable area
        DetectPlantingArea();

        // Attempt to plant if in range and player has seed
        if (canPlant && Input.GetKeyDown(plantKey))
        {
            Debug.Log("Attempting to plant seed.");
            if (inventorySystem.HasSeed()) // Check for seed in inventory
            {
                Debug.Log("Seed is in inventory. Planting...");
                PlantSeed();
            }
            else
            {
                Debug.LogWarning("Cannot plant seed: No seed in inventory.");
            }
        }
    }

    void DetectPlantingArea()
    {
        // Check for a valid planting area within range
        Collider2D hit = Physics2D.OverlapCircle(transform.position, plantingRange, plantingLayer);

        if (hit != null)
        {
            canPlant = true;
            plantingAreaCollider = hit; // Store the collider
            Debug.Log($"Found valid planting area at {hit.transform.position}");
        }
        else
        {
            canPlant = false;
            plantingAreaCollider = null;
            Debug.Log("No valid planting area detected.");
        }

        // Show or hide planting indicator
        plantingIndicator.SetActive(canPlant);
        if (canPlant)
        {
            plantingIndicator.transform.position = transform.position + Vector3.up * 1.5f;
            Debug.Log("Plant seed indicator is visible.");
        }
        else
        {
            plantingIndicator.SetActive(false);
            Debug.Log("Plant seed indicator is hidden.");
        }
    }

    void PlantSeed()
    {
        if (canPlant && inventorySystem.HasSeed())
        {
            Debug.Log("Planting seed...");
            
            // Instantiate the seed at the planting area location
            Vector3 plantingPosition = plantingAreaCollider.transform.position;
            Instantiate(seedPrefab, plantingPosition, Quaternion.identity);  // Create the seed at the planting area
            
            // Remove the seed from the inventory
            inventorySystem.RemoveItem("Seed");
        }
        else
        {
            Debug.LogWarning("Cannot plant seed: Either no valid area or no seed in inventory.");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the range in the editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, plantingRange);
    }
}