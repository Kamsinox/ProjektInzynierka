using UnityEngine;
using System.Xml;
using System.IO;

public class XMLFile : MonoBehaviour
{
    void Start()
    {
        //jeżeli nie ma pliku to utworzy z pustymi danymi
        //w przeciwnym wypadku nic nie zrobi, żeby nie nadpisać pustym plikiem
        if(!File.Exists(Application.dataPath + "/Data.txt")) 
        createXMLFile();
    }

    private void createXMLFile()
    {
        
            XmlDocument xmlDocument = new XmlDocument();

            XmlElement root = xmlDocument.CreateElement("Save");
            //root.SetAttribute("FileName", "Data");

            XmlElement coinsElement = xmlDocument.CreateElement("Coins");
            coinsElement.InnerText = "0";
            root.AppendChild(coinsElement);
            XmlElement allCoinsElement = xmlDocument.CreateElement("AllCoins");
            allCoinsElement.InnerText = "0";
            root.AppendChild(allCoinsElement);

            xmlDocument.AppendChild(root);
            xmlDocument.Save(Application.dataPath + "/Data.txt");

            if(File.Exists(Application.dataPath + "/Data.txt"))
            {
                Debug.Log("XML FILE SAVED" + Application.dataPath);
            }
    }


}
