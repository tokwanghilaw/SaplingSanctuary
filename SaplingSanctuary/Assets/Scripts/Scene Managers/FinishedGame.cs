using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishedGame : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("TitleScreen");
    }

}
