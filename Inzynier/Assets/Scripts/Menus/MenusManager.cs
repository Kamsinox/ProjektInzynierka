using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusManager : MonoBehaviour
{
    public void loadSceneKursEasyChoose()
    {
        SceneManager.LoadScene(sceneName:"CourseEasyChoose");
    }
    public void loadSceneKursNormalChoose()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalChoose");
    }
    public void loadSceneKursHardChoose()
    {
        SceneManager.LoadScene(sceneName:"CourseHardChoose");
    }
    public void loadSceneKursHardcoreChoose()
    {
        SceneManager.LoadScene(sceneName:"CourseHardcoreChoose");
    }
    public void loadSceneFreePlay()
    {
        SceneManager.LoadScene(sceneName:"FreePlay");
    }
}
