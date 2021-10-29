using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void loadSceneMenuChoose()
    {
        SceneManager.LoadScene(sceneName:"MenuChoose");
    }
    public void loadProfile()
    {
        SceneManager.LoadScene(sceneName:"Profil");
    }
}
