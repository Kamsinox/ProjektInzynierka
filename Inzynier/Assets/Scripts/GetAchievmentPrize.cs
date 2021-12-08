using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class GetAchievmentPrize : MonoBehaviour
{
    private string type;
    private int idAch;
    public void getAchievmentPrize(Image image)
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList achievmentsXml = xmlDocument.GetElementsByTagName("Achievments");

            string prizeName = image.sprite.name;
            for(int i=0; i<achievmentsXml[0].ChildNodes.Count; i++)
            {
                if(prizeName == achievmentsXml[0].ChildNodes[i].ChildNodes[0].InnerText)
                {
                    type = achievmentsXml[0].ChildNodes[i].ChildNodes[2].InnerText;
                    idAch = i;
                }  
            }

            switch(type)
            {
                case "Profile":
                    XmlNodeList profileImageTag = xmlDocument.GetElementsByTagName("ProfileImages");
                    XmlElement profileImage = xmlDocument.CreateElement("Image");
                    profileImage.InnerText = prizeName;
                    profileImageTag[0].AppendChild(profileImage);
                    achievmentsXml[0].ChildNodes[idAch].ChildNodes[5].InnerText = "1";
                break;

                case "Background":
                    XmlNodeList backgroundTag = xmlDocument.GetElementsByTagName("Backgrounds");
                    XmlElement backgroundElement = xmlDocument.CreateElement("Background");
                    backgroundElement.InnerText = prizeName;
                    backgroundTag[0].AppendChild(backgroundElement);
                    achievmentsXml[0].ChildNodes[idAch].ChildNodes[5].InnerText = "1";
                break;

                case "Frame":
                    XmlNodeList profileFrameTag = xmlDocument.GetElementsByTagName("ProfileFrames");
                    XmlElement profileFrame = xmlDocument.CreateElement("Frame");
                    profileFrame.InnerText = prizeName;
                    profileFrameTag[0].AppendChild(profileFrame);
                    achievmentsXml[0].ChildNodes[idAch].ChildNodes[5].InnerText = "1";
                break;

                default: Debug.Log("Błąd przy odczytywaniu typu nagrody"); break;

            }

            xmlDocument.Save(filePath);
        }
        else Debug.Log("Błąd przy odbieraniu nagrody z achievmentu" + filePath);

    }
}
