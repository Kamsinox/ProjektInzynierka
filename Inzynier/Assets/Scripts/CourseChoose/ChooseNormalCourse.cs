using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChooseNormalCourse : MonoBehaviour
{
    public static int currentCourse = 0;
 
    #region loadScenes
    public void loadSceneKursNormal1()
    {
        SceneManager.LoadScene(sceneName:"CourseNormal1");
        currentCourse = 0;
    }
    public void loadSceneKursNormal2()
    {
        SceneManager.LoadScene(sceneName:"CourseNormal2");
        currentCourse = 1;
    }
    public void loadSceneKursNormal3()
    {
        SceneManager.LoadScene(sceneName:"CourseNormal3");
        currentCourse = 2;
    }
    public void loadSceneKursNormal4()
    {
        SceneManager.LoadScene(sceneName:"CourseNormal4");
        currentCourse = 3;
    }
    public void loadSceneKursNormal5()
    {
        SceneManager.LoadScene(sceneName:"CourseNormal5");
        currentCourse = 4;
    }
    public void loadSceneKursNormal6()
    {
        SceneManager.LoadScene(sceneName:"CourseNormal6");
        currentCourse = 5;
    }
    public void loadSceneKursNormal7()
    {
        SceneManager.LoadScene(sceneName:"CourseNormal7");
        currentCourse = 6;
    }
    public void loadSceneKursNormal8()
    {
        SceneManager.LoadScene(sceneName:"CourseNormal8");
        currentCourse = 7;
    }
    public void loadSceneKursNormal9()
    {
        SceneManager.LoadScene(sceneName:"CourseNormal9");
        currentCourse = 8;
    }
    #endregion


    #region onEnter/onExit
    //wyświwetlanie jaki kurs ma się zamiar wybrać
    public void onExit(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = " ";
    }
    public void onEnter1(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "1";
    }
    public void onEnter2(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "2";
    }
    public void onEnter3(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "3";
    }
    public void onEnter4(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "4";
    }
    public void onEnter5(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "5";
    }
    public void onEnter6(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "6";
    }
    public void onEnter7(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "7";
    }
    public void onEnter8(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "8";
    }
    public void onEnter9(){
        GameObject.Find("InfoText").GetComponentInChildren<TextMeshProUGUI>().text = "9";
    }
    #endregion
}
