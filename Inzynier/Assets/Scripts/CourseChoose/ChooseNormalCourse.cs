using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChooseNormalCourse : MonoBehaviour
{
    void Start()
    {
        EasyCourseManager.courseID = 2;
    }
 
    #region loadScenes
    public void loadSceneKursNormal1()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalSekunda");
        EasyCourseManager.currentCourse = 0;
    }
    public void loadSceneKursNormal2()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalTercja");
        EasyCourseManager.currentCourse = 1;
    }
    public void loadSceneKursNormal3()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalKwaKwi");
        EasyCourseManager.currentCourse = 2;
    }
    public void loadSceneKursNormal4()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalSeksta");
        EasyCourseManager.currentCourse = 3;
    }
    public void loadSceneKursNormal5()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalSeptyma");
        EasyCourseManager.currentCourse = 4;
    }
    public void loadSceneKursNormal6()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalPrymaSekunda");
        EasyCourseManager.currentCourse = 5;
    }
    public void loadSceneKursNormal7()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalTercjaKwarta");
        EasyCourseManager.currentCourse = 6;
    }
    public void loadSceneKursNormal8()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalKwintaSeksta");
        EasyCourseManager.currentCourse = 7;
    }
    public void loadSceneKursNormal9()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalSeptymaOktawa");
        EasyCourseManager.currentCourse = 8;
    }
    #endregion


    #region onEnter/onExit
    //wyświwetlanie jaki kurs ma się zamiar wybrać
    public void onExit(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = " ";
    }
    public void onEnter1(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Sekunda \n mała i wielka";
    }
    public void onEnter2(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Tercja \n mała i wielka";
    }
    public void onEnter3(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Kwarta \n i kwinta";
    }
    public void onEnter4(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Seksta \n mała i wielka";
    }
    public void onEnter5(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Septyma \n mała i wielka";
    }
    public void onEnter6(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Pryma \n i sekundy";
    }
    public void onEnter7(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Tercje \n i kwarta";
    }
    public void onEnter8(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Kwinta \n i seksty";
    }
    public void onEnter9(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "Septymy \n i oktawa";
    }
    #endregion
}
