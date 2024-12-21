using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeCounterManager : MonoBehaviour
{
    public string winSceneName = "Win";
    private const int winTreeCount = 12;

    void Update()
    {
        CountTrees();
    }

    void CountTrees()
    {
        // Find all GameObjects with the name "Tree"
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");

        // Check if the count reaches the winning number
        if (trees.Length == winTreeCount)
        {
            Debug.Log("You have planted 12 trees! Loading win scene...");
            SceneManager.LoadScene("Win");
        }
    }
}
