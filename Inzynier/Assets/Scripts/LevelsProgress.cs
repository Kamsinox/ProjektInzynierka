using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class LevelsProgress : MonoBehaviour
{
    public Button[] levelsBtn;

    void Start()
    {
        progressLevel();
    }

    private void progressLevel()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            XmlNodeList levels = xmlDocument.GetElementsByTagName("LevelsProgress"); 

            for(int i=0; i<levels[0].ChildNodes.Count; i++)
            {
                if(levels[0].ChildNodes[i].InnerText == "1") levelsBtn[i].interactable = true;
                else levelsBtn[i].interactable = false;
            }
        }
        else Debug.Log("FILE NOT LOADED for progressLevel" + filePath);
    }
}
