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
    [Space]
    public Button[] buttonBackgrounds;
    [Space]
    public Button[] buttonFrames;

    void Start()
    {
        buttonStart.onClick.Invoke();
        buttonStart.Select();
        loadAllImages();
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

    public void loadAllImages()
    {
        string filePath = Application.dataPath + "/Data.txt";
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(filePath);

        #region loadProfileImages
        List<string> nazwyProfil = new List<string>();
        XmlNodeList list1 = xmlDocument.GetElementsByTagName("ProfileImages");
        foreach(XmlNode x in list1[0].ChildNodes)
        {
            nazwyProfil.Add(x.InnerText);
        }

        for(int i=0; i<nazwyProfil.Count; i++)
        {
            for(int j=0; j<buttonImages.Length; j++)
            {
                if(buttonImages[j].GetComponent<Image>().sprite.name == nazwyProfil[i])
                {
                    buttonImages[j].interactable = true;
                }
            }
        }
        #endregion

        #region loadBackgroundImages
        List<string> nazwyBackgorund = new List<string>();
        XmlNodeList list2 = xmlDocument.GetElementsByTagName("Backgrounds");
        foreach(XmlNode x in list2[0].ChildNodes)
        {
            nazwyBackgorund.Add(x.InnerText);
        }

        for(int i=0; i<nazwyBackgorund.Count; i++)
        {
            for(int j=0; j<buttonBackgrounds.Length; j++)
            {
                if(buttonBackgrounds[j].GetComponent<Image>().sprite.name == nazwyBackgorund[i])
                {
                    buttonBackgrounds[j].interactable = true;
                }
            }
        }
        #endregion

        #region loadFrameImages
        List<string> nazwyFrame = new List<string>();
        XmlNodeList list3 = xmlDocument.GetElementsByTagName("ProfileFrames");
        foreach(XmlNode x in list3[0].ChildNodes)
        {
            nazwyFrame.Add(x.InnerText);
        }

        for(int i=0; i<nazwyFrame.Count; i++)
        {
            for(int j=0; j<buttonFrames.Length; j++)
            {
                if(buttonFrames[j].GetComponent<Image>().sprite.name == nazwyFrame[i])
                {
                    buttonFrames[j].interactable = true;
                }
            }
        }
        #endregion
        
    }
}
