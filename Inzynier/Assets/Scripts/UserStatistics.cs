using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml;
using System.IO;

public class UserStatistics : MonoBehaviour
{
    public List<TMP_Text> textArea = new List<TMP_Text>();
    private string textToSave;
    void Start()
    {
        showStats();
    }

    private void showStats()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList allCoins = xmlDocument.GetElementsByTagName("AllCoins");
            textToSave = allCoins[0].InnerText.ToString(); 
            textArea[0].text = string.Format("Wszystkie zebrane monety: "+textToSave);

            XmlNodeList currentProfile = xmlDocument.GetElementsByTagName("CurrentProfileImage");
            textToSave = currentProfile[0].InnerText.ToString();
            textArea[1].text = string.Format("Zdjęcie profilowe: "+textToSave);

            XmlNodeList currentBackground = xmlDocument.GetElementsByTagName("CurrentBackground");
            textToSave = currentBackground[0].InnerText.ToString();
            textArea[2].text = string.Format("Tło: "+textToSave);

            XmlNodeList currentFrame = xmlDocument.GetElementsByTagName("CurrentFrame");
            textToSave = currentFrame[0].InnerText.ToString();
            textArea[3].text = string.Format("Ramka: "+textToSave);

        }
        else Debug.Log("FILE NOT LOADED for showing stats" + filePath);
    }
}
