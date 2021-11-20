using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChooseEasyCourse : MonoBehaviour
{
    public static int currentCourse = 0;
 
    void Start()
    {
        EasyCourseManager.courseID = 1;
    }

    #region loadScenes
    public void loadSceneKursEasy1()
    {
        SceneManager.LoadScene(sceneName:"CourseEasyPryOkt");
        currentCourse = 0;
    }
    public void loadSceneKursEasy2()
    {
        SceneManager.LoadScene(sceneName:"CourseEasySekunda");
        currentCourse = 1;
    }
    public void loadSceneKursEasy3()
    {
        SceneManager.LoadScene(sceneName:"CourseEasyTercja");
        currentCourse = 2;
    }
    public void loadSceneKursEasy4()
    {
        SceneManager.LoadScene(sceneName:"CourseEasyKwaKwi");
        currentCourse = 3;
    }
    public void loadSceneKursEasy5()
    {
        SceneManager.LoadScene(sceneName:"CourseEasySeksta");
        currentCourse = 4;
    }
    public void loadSceneKursEasy6()
    {
        SceneManager.LoadScene(sceneName:"CourseEasySeptyma");
        currentCourse = 5;
    }
    #endregion

    #region onEnter/onExit
    //wyświwetlanie jaki kurs ma się zamiar wybrać
    public void onExit(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = " ";
    }
    public void onEnter1(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Pryma \n i oktawa";
    }
    public void onEnter2(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Sekunda \n mała i wielka";
    }
    public void onEnter3(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Tercja \n mała i wielka";
    }
    public void onEnter4(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Kwinta \n i kwarta";
    }
    public void onEnter5(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Seksta \n mała i wielka";
    }
    public void onEnter6(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Septyma \n mała i wielka";
    }
    #endregion
}
