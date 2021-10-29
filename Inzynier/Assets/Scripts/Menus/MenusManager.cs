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
}
