using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChooseHardcoreCourse : MonoBehaviour
{

    void Start()
    {
        EasyCourseManager.courseID = 4;
    }

    #region loadScenes
    public void loadSceneKursHardcore1()
    {
        SceneManager.LoadScene(sceneName:"CourseHardcore1");
        EasyCourseManager.currentCourse = 0;
    }
    public void loadSceneKursHardcore2()
    {
        SceneManager.LoadScene(sceneName:"CourseHardcore2");
        EasyCourseManager.currentCourse = 1;
    }
    #endregion

    #region onEnter/onExit
    //wyświwetlanie jaki kurs ma się zamiar wybrać
    public void onExit(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = " ";
    }
    public void onEnter1(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Od sekundy małej \n do kwarty";
    }
    public void onEnter2(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Od kwinty \n do septymy wielkiej";
    }
    #endregion
}
