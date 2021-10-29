using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChooseNormalCourse : MonoBehaviour
{
    public static int currentCourse = 0;
 
    #region loadScenes
    public void loadSceneKursNormal1()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalSekunda");
        currentCourse = 0;
    }
    public void loadSceneKursNormal2()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalTercja");
        currentCourse = 1;
    }
    public void loadSceneKursNormal3()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalKwaKwi");
        currentCourse = 2;
    }
    public void loadSceneKursNormal4()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalSeksta");
        currentCourse = 3;
    }
    public void loadSceneKursNormal5()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalSeptyma");
        currentCourse = 4;
    }
    public void loadSceneKursNormal6()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalPrymaSekunda");
        currentCourse = 5;
    }
    public void loadSceneKursNormal7()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalTercjaKwarta");
        currentCourse = 6;
    }
    public void loadSceneKursNormal8()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalKwintaSeksta");
        currentCourse = 7;
    }
    public void loadSceneKursNormal9()
    {
        SceneManager.LoadScene(sceneName:"CourseNormalSeptymaOktawa");
        currentCourse = 8;
    }
    #endregion


    #region onEnter/onExit
    //wyświwetlanie jaki kurs ma się zamiar wybrać
    public void onExit(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = " ";
    }
    public void onEnter1(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "CourseNormalSekunda";
    }
    public void onEnter2(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "CourseNormalTercja";
    }
    public void onEnter3(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "CourseNormalKwaKwi";
    }
    public void onEnter4(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "CourseNormalSeksta";
    }
    public void onEnter5(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "CourseNormalSeptyma";
    }
    public void onEnter6(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "CourseNormalPrymaSekunda";
    }
    public void onEnter7(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "CourseNormalTercjaKwarta";
    }
    public void onEnter8(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "CourseNormalKwintaSeksta";
    }
    public void onEnter9(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "CourseNormalSeptymaOktawa";
    }
    #endregion
}
