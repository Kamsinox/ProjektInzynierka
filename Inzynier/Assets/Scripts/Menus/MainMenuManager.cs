using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject[] scenes;

    //kolejność w ustawianiu scen ma znaczenie (w zależności od tablicy)
    //do przełączania pomiędzy gameobjecty w menu
    public void loadMenuChoose()
    {
        foreach(GameObject g in scenes) g.SetActive(false);
        scenes[0].SetActive(true);
    }
    public void loadProfile()
    {
        foreach(GameObject g in scenes) g.SetActive(false);
        scenes[1].SetActive(true);
    }


    //przełączanie między scenami
    public void loadSceneMenuChoose()
    {
        SceneManager.LoadScene(sceneName:"MenuChoose");
    }
}
