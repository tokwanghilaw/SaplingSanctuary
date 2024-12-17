using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlantableAreaManager : MonoBehaviour
{
    public List<Vector2> plantablePositions = new List<Vector2>(); // Tracks plantable zones
    public LayerMask plantableAreaLayer;

    void Start()
    {
        // Add initial plantable area around the player spawn
        AddPlantableArea(new Vector2(transform.position.x, transform.position.y));
    }

    public void AddPlantableArea(Vector2 position)
    {
        if (!plantablePositions.Contains(position))
        {
            plantablePositions.Add(position);
            // Visualize the area (e.g., change tile or add marker)
        }
    }

    public bool IsPlantable(Vector2 position)
    {
        return plantablePositions.Contains(position);
    }
}
