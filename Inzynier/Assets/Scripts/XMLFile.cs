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
            root.SetAttribute("FileName", "Data");

                XmlElement coinsElement = xmlDocument.CreateElement("Coins");
                coinsElement.InnerText = "0";
                root.AppendChild(coinsElement);
                
                XmlElement allCoinsElement = xmlDocument.CreateElement("AllCoins");
                allCoinsElement.InnerText = "0";
                root.AppendChild(allCoinsElement);

                XmlElement currentProfileImageElement = xmlDocument.CreateElement("CurrentProfileImage");
                currentProfileImageElement.InnerText = "";
                root.AppendChild(currentProfileImageElement);

                XmlElement currentBackgroundElement = xmlDocument.CreateElement("CurrentBackground");
                currentBackgroundElement.InnerText = "";
                root.AppendChild(currentBackgroundElement);

                XmlElement currentFrameElement = xmlDocument.CreateElement("CurrentFrame");
                currentFrameElement.InnerText = "";
                root.AppendChild(currentFrameElement);

                XmlElement notesPlayedElement = xmlDocument.CreateElement("FreePlayNotesPlayed");
                notesPlayedElement.InnerText="0";
                root.AppendChild(notesPlayedElement);

                #region Shop
                XmlElement shop = xmlDocument.CreateElement("Shop");
                root.AppendChild(shop);

                     XmlElement profileElement = xmlDocument.CreateElement("ProfileImages");
                     shop.AppendChild(profileElement);

                     XmlElement backgroundElement = xmlDocument.CreateElement("Backgrounds");
                     shop.AppendChild(backgroundElement);

                     XmlElement frameElement = xmlDocument.CreateElement("ProfileFrames");
                     shop.AppendChild(frameElement);
                #endregion

                #region CoureHighScores
                XmlElement highscores = xmlDocument.CreateElement("Highscores");
                root.AppendChild(highscores);

                    #region CourseEasy
                    XmlElement courseEasy = xmlDocument.CreateElement("EasyCourse");
                    highscores.AppendChild(courseEasy);

                        XmlElement courseEasy1 = xmlDocument.CreateElement("EasyPrymaOktawa");
                        courseEasy1.InnerText="0";
                        courseEasy.AppendChild(courseEasy1);

                        XmlElement courseEasy2 = xmlDocument.CreateElement("EasySekunda");
                        courseEasy2.InnerText="0";
                        courseEasy.AppendChild(courseEasy2);

                        XmlElement courseEasy3 = xmlDocument.CreateElement("EasyTercja");
                        courseEasy3.InnerText="0";
                        courseEasy.AppendChild(courseEasy3);

                        XmlElement courseEasy4 = xmlDocument.CreateElement("EasyKwaKwi");
                        courseEasy4.InnerText="0";
                        courseEasy.AppendChild(courseEasy4);

                        XmlElement courseEasy5 = xmlDocument.CreateElement("EasySeksta");
                        courseEasy5.InnerText="0";
                        courseEasy.AppendChild(courseEasy5);

                        XmlElement courseEasy6 = xmlDocument.CreateElement("EasySeptyma");
                        courseEasy6.InnerText="0";
                        courseEasy.AppendChild(courseEasy6);
                    #endregion

                    #region CourseNormal
                    XmlElement courseNomral = xmlDocument.CreateElement("NormalCourse");
                    highscores.AppendChild(courseNomral);

                        XmlElement courseNormal1 = xmlDocument.CreateElement("NormalSekunda");
                        courseNormal1.InnerText="0";
                        courseNomral.AppendChild(courseNormal1);

                        XmlElement courseNormal2 = xmlDocument.CreateElement("NormalTercja");
                        courseNormal2.InnerText="0";
                        courseNomral.AppendChild(courseNormal2);

                        XmlElement courseNormal3 = xmlDocument.CreateElement("NormalKwaKwi");
                        courseNormal3.InnerText="0";
                        courseNomral.AppendChild(courseNormal3);

                        XmlElement courseNormal4 = xmlDocument.CreateElement("NormalSeksta");
                        courseNormal4.InnerText="0";
                        courseNomral.AppendChild(courseNormal4);

                        XmlElement courseNormal5 = xmlDocument.CreateElement("NormalSeptyma");
                        courseNormal5.InnerText="0";
                        courseNomral.AppendChild(courseNormal5);

                        XmlElement courseNormal6 = xmlDocument.CreateElement("NormalPrySek");
                        courseNormal6.InnerText="0";
                        courseNomral.AppendChild(courseNormal6);

                        XmlElement courseNormal7 = xmlDocument.CreateElement("NormalTerKwa");
                        courseNormal7.InnerText="0";
                        courseNomral.AppendChild(courseNormal7);

                        XmlElement courseNormal8 = xmlDocument.CreateElement("NormalKwiSek");
                        courseNormal8.InnerText="0";
                        courseNomral.AppendChild(courseNormal8);

                        XmlElement courseNormal9 = xmlDocument.CreateElement("NormalSepOkt");
                        courseNormal9.InnerText="0";
                        courseNomral.AppendChild(courseNormal9);

                    #endregion

                    #region CourseHard
                    XmlElement courseHard = xmlDocument.CreateElement("HardCourse");
                    highscores.AppendChild(courseHard);

                        XmlElement courseHard1 = xmlDocument.CreateElement("HardUno");
                        courseHard1.InnerText="0";
                        courseHard.AppendChild(courseHard1);

                        XmlElement courseHard2 = xmlDocument.CreateElement("HardDos");
                        courseHard2.InnerText="0";
                        courseHard.AppendChild(courseHard2);

                        XmlElement courseHard3 = xmlDocument.CreateElement("HardTres");
                        courseHard3.InnerText="0";
                        courseHard.AppendChild(courseHard3);

                    #endregion

                    #region CourseHardcore
                    XmlElement courseHardcore = xmlDocument.CreateElement("HardcoreCourse");
                    highscores.AppendChild(courseHardcore);

                        XmlElement courseHardcore1 = xmlDocument.CreateElement("HardcoreIchi");
                        courseHardcore1.InnerText="0";
                        courseHardcore.AppendChild(courseHardcore1);

                        XmlElement courseHardcore2 = xmlDocument.CreateElement("HardcoerNi");
                        courseHardcore2.InnerText="0";
                        courseHardcore.AppendChild(courseHardcore2);

                    #endregion

                #endregion

            xmlDocument.AppendChild(root);

            xmlDocument.Save(Application.dataPath + "/Data.txt");

            if(File.Exists(Application.dataPath + "/Data.txt"))
            {
                Debug.Log("XML FILE SAVED" + Application.dataPath);
            }
    }
}
