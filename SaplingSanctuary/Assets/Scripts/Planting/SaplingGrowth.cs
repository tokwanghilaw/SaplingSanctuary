using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaplingGrowth : MonoBehaviour
{
    public float growthTime = 10f; // Time in seconds for sapling to grow into a tree
    public GameObject treePrefab; // Reference to the tree prefab

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= growthTime)
        {
            GrowIntoTree();
        }
    }

    void GrowIntoTree()
    {
        Instantiate(treePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); // Remove the sapling after it grows
    }
}