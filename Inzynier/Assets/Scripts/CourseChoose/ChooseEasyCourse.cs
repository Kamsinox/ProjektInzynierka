using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChooseEasyCourse : MonoBehaviour
{
    void Start()
    {
        CourseManager.courseID = 1;
    }

    #region loadScenes
    public void loadSceneKursEasy1()
    {
        SceneManager.LoadScene(sceneName:"CourseEasyPryOkt");
        CourseManager.currentCourse = 0;
    }
    public void loadSceneKursEasy2()
    {
        SceneManager.LoadScene(sceneName:"CourseEasySekunda");
        CourseManager.currentCourse = 1;
    }
    public void loadSceneKursEasy3()
    {
        SceneManager.LoadScene(sceneName:"CourseEasyTercja");
        CourseManager.currentCourse = 2;
    }
    public void loadSceneKursEasy4()
    {
        SceneManager.LoadScene(sceneName:"CourseEasyKwaKwi");
        CourseManager.currentCourse = 3;
    }
    public void loadSceneKursEasy5()
    {
        SceneManager.LoadScene(sceneName:"CourseEasySeksta");
        CourseManager.currentCourse = 4;
    }
    public void loadSceneKursEasy6()
    {
        SceneManager.LoadScene(sceneName:"CourseEasySeptyma");
        CourseManager.currentCourse = 5;
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
