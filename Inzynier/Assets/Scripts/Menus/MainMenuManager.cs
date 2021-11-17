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

    /*public void loadMenuChoose()
    {
        //może się kiedyś przydać
        foreach(GameObject g in scenes) g.SetActive(false);
        scenes[0].SetActive(true);
    }*/
}
