using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileMenuManager : MonoBehaviour
{
    public GameObject[] panele;
    public Button buttonStart;
    void Start()
    {
        buttonStart.onClick.Invoke();
        buttonStart.Select();
    }

    public void changePanelStats()
    {
        foreach(GameObject g in panele)
        {
            g.SetActive(false);
        }

        panele[0].SetActive(true);
    }

    public void changePanelProflieImage()
    {
        foreach(GameObject g in panele)
        {
            g.SetActive(false);
        }

        panele[1].SetActive(true);
    }

    public void changePanelBackground()
    {
        foreach(GameObject g in panele)
        {
            g.SetActive(false);
        }

        panele[2].SetActive(true);
    }

    public void changePanelOther()
    {
        foreach(GameObject g in panele)
        {
            g.SetActive(false);
        }

        panele[3].SetActive(true);
    }

    public void changePanelAchievments()
    {
        foreach(GameObject g in panele)
        {
            g.SetActive(false);
        }

        panele[4].SetActive(true);
    }


}
