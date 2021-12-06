using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChooseHardCourse : MonoBehaviour
{
    void Start()
    {
        EasyCourseManager.courseID = 3;
    }

    #region loadScenes
    public void loadSceneKursHard1()
    {
        SceneManager.LoadScene(sceneName:"CourseHard1");
        EasyCourseManager.currentCourse = 0;
    }
    public void loadSceneKursHard2()
    {
        SceneManager.LoadScene(sceneName:"CourseHard2");
        EasyCourseManager.currentCourse = 1;
    }
    public void loadSceneKursHard3()
    {
        SceneManager.LoadScene(sceneName:"CourseHard3");
        EasyCourseManager.currentCourse = 2;
    }
    #endregion

    #region onEnter/onExit
    //wyświwetlanie jaki kurs ma się zamiar wybrać
    public void onExit(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = " ";
    }
    public void onEnter1(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Pryma, sekundy \n i tercja mała";
    }
    public void onEnter2(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Tercja wielka, \n kwarta i kwinta";
    }
    public void onEnter3(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Seksty, septymy \n i oktawa";
    }
    #endregion
}
