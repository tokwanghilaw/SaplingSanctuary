using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        //Replace "GameScene" with the name of the main game scene
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
