using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class ProfileMenuManager : MonoBehaviour
{
    public GameObject[] panele;
    public Button buttonStart;

    [Space]
    public Button[] buttonImages;
    void Start()
    {
        buttonStart.onClick.Invoke();
        buttonStart.Select();
        loadAllProfileImages();
    }

    #region changePanel
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
    #endregion

    private void loadAllProfileImages()
    {
        List<string> nazwy = new List<string>();

        string filePath = Application.dataPath + "/Data.txt";
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(filePath);

        XmlNodeList list = xmlDocument.GetElementsByTagName("ProfileImages");
        foreach(XmlNode x in list[0].ChildNodes)
        {
            nazwy.Add(x.InnerText);
        }

        for(int i=0; i<nazwy.Count; i++)
        {
            for(int j=0; j<buttonImages.Length; j++)
            {
                if(buttonImages[j].GetComponent<Image>().sprite.name == nazwy[i])
                {
                    buttonImages[j].interactable = true;
                }
            }
        }
    }
}
