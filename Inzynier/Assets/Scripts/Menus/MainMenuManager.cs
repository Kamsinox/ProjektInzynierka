using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void loadSceneProfile()
    {
        SceneManager.LoadScene(sceneName:"Profile");
    }
    public void loadSceneMenuChoose()
    {
        SceneManager.LoadScene(sceneName:"MenuChoose");
    }

    public void loadShop()
    {
        SceneManager.LoadScene(sceneName:"Shop");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void exitApp()
    {
        Application.Quit();
    }
}
