using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    public float pickupRange = 2f; // Range to detect pickups
    public KeyCode pickupKey = KeyCode.E; // Key to pick up items
    public InventorySystem inventorySystem; // Reference to the InventorySystem

    private Pickupable nearbyPickupable;

    void Update()
    {
        DetectPickupable();

        if (nearbyPickupable != null && Input.GetKeyDown(pickupKey))
        {
            PickUpItem();
        }
    }

    void DetectPickupable()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickupRange);

        Pickupable closestPickupable = null;
        float closestDistance = pickupRange;

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Pickupable pickupable))
            {
                Debug.Log($"Found pickupable: {pickupable.GetName()}"); // Log detected items
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPickupable = pickupable;
                }
            }
        }

        // Highlight the closest pickupable
        if (closestPickupable != nearbyPickupable)
        {
            if (nearbyPickupable != null)
                nearbyPickupable.Highlight(false);

            nearbyPickupable = closestPickupable;

            if (nearbyPickupable != null)
            {
                Debug.Log($"Highlighting: {nearbyPickupable.GetName()}"); // Log highlighted item
                nearbyPickupable.Highlight(true);
            }
        }
    }

    void PickUpItem()
    {
        if (nearbyPickupable != null)
        {
            if (nearbyPickupable.GetName() == "Seed")
            {
                // Add seed to the inventory
                inventorySystem.AddSeedToInventory();  // Ensure it adds "Seed" to inventory
            }
            else
            {
                // Add other items to the inventory
                inventorySystem.AddItem(nearbyPickupable.GetName());
            }

            // Destroy the item GameObject
            Destroy(nearbyPickupable.gameObject);
            nearbyPickupable = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}