using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml;
using System.IO;
using System;

public class UserStatistics : MonoBehaviour
{
    public List<TMP_Text> textArea = new List<TMP_Text>();
    private string textToSave;
    private double procent;
    private int amount;

    public void showStatsInMenu()
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
            textArea[0].text = string.Format(textToSave);

            XmlNodeList amountOfProfiles = xmlDocument.GetElementsByTagName("ProfileImages");
            textArea[1].text = string.Format(allImages(amountOfProfiles) + "/13");

            XmlNodeList amountOfBackgrounds = xmlDocument.GetElementsByTagName("Backgrounds");
            textArea[2].text = string.Format(allImages(amountOfBackgrounds) + "/9");

            XmlNodeList amountOfFrames = xmlDocument.GetElementsByTagName("ProfileFrames");
            textArea[3].text = string.Format(allImages(amountOfFrames) + "/12");

            XmlNodeList freeplayNotesPlayed = xmlDocument.GetElementsByTagName("FreePlayNotesPlayed");
            textToSave = freeplayNotesPlayed[0].InnerText.ToString();
            textArea[4].text = string.Format(textToSave);


            XmlNodeList percentEasy = xmlDocument.GetElementsByTagName("EasyCourse");
            textArea[5].text = string.Format(percentCalc(percentEasy,28) + "%");

            XmlNodeList percentNormal = xmlDocument.GetElementsByTagName("NormalCourse");
            textArea[6].text = string.Format(percentCalc(percentNormal,46) + "%");

            XmlNodeList percentHard = xmlDocument.GetElementsByTagName("HardCourse");
            textArea[7].text = string.Format(percentCalc(percentHard,24) + "%");

            XmlNodeList percentHardcore = xmlDocument.GetElementsByTagName("HardcoreCourse");
            textArea[8].text = string.Format(percentCalc(percentHardcore,20) + "%");


            
        }
        else Debug.Log("FILE NOT LOADED for showing stats" + filePath);
    }

    private double percentCalc(XmlNodeList nodeList, int amountLevels)
    {
        //ustalanie procentów ukończenia danego kursu
        procent = 0;
        foreach(XmlNode x in nodeList[0].ChildNodes)
        {
            procent += float.Parse(x.InnerText);
        }

        //zwracamy jako zaokrągloną liczbę dp dwóch miejsc po przecinku
        procent = Math.Round((procent/amountLevels)*100, 2);
        return procent;
    }

    private int allImages(XmlNodeList nodeList)
    {
        //zliczanie image z xml
        amount = 0;
        foreach (XmlNode x in nodeList[0].ChildNodes) amount++;
        return amount;
    }
}
