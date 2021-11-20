using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChooseHardcoreCourse : MonoBehaviour
{
    public static int currentCourse = 0;

    void Start()
    {
        EasyCourseManager.courseID = 4;
    }

    #region loadScenes
    public void loadSceneKursHardcore1()
    {
        SceneManager.LoadScene(sceneName:"CourseHardcore1");
        currentCourse = 0;
    }
    public void loadSceneKursHardcore2()
    {
        SceneManager.LoadScene(sceneName:"CourseHardcore2");
        currentCourse = 1;
    }
    #endregion

    #region onEnter/onExit
    //wyświwetlanie jaki kurs ma się zamiar wybrać
    public void onExit(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = " ";
    }
    public void onEnter1(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Are you sure about that?";
    }
    public void onEnter2(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Really?";
    }
    #endregion
}
