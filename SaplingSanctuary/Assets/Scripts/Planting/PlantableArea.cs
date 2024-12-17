using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantableArea : MonoBehaviour
{
    public bool playerInPlantableArea;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInPlantableArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInPlantableArea = false;
        }
    }
}
