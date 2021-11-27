
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
        {
            createXMLFile();
            
            //utworzenie osiągnięć
            AchievmentsManager.achievmentsManagerInstance.writeAchievmentsToXml();
        }
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
                
                #region CoursesProgress
                XmlElement courseProgress = xmlDocument.CreateElement("CoursesProgress");
                root.AppendChild(courseProgress);

                    #region CourseEasy
                    XmlElement courseEasyProgress = xmlDocument.CreateElement("EasyCourseProgress");
                    courseProgress.AppendChild(courseEasyProgress);

                        XmlElement courseEasyProgress1 = xmlDocument.CreateElement("EasyPrymaOktawaProgress");
                        courseEasyProgress1.InnerText="1";
                        courseEasyProgress.AppendChild(courseEasyProgress1);

                        XmlElement courseEasyProgress2 = xmlDocument.CreateElement("EasySekundaProgress");
                        courseEasyProgress2.InnerText="0";
                        courseEasyProgress.AppendChild(courseEasyProgress2);

                        XmlElement courseEasyProgress3 = xmlDocument.CreateElement("EasyTercjaProgress");
                        courseEasyProgress3.InnerText="0";
                        courseEasyProgress.AppendChild(courseEasyProgress3);

                        XmlElement courseEasyProgress4 = xmlDocument.CreateElement("EasyKwaKwiProgress");
                        courseEasyProgress4.InnerText="0";
                        courseEasyProgress.AppendChild(courseEasyProgress4);

                        XmlElement courseEasyProgress5 = xmlDocument.CreateElement("EasySekstaProgress");
                        courseEasyProgress5.InnerText="0";
                        courseEasyProgress.AppendChild(courseEasyProgress5);

                        XmlElement courseEasyProgress6 = xmlDocument.CreateElement("EasySeptymaProgress");
                        courseEasyProgress6.InnerText="0";
                        courseEasyProgress.AppendChild(courseEasyProgress6);
                    #endregion

                    #region CourseNormal
                    XmlElement courseNomralProgress = xmlDocument.CreateElement("NormalCourseProgress");
                    courseProgress.AppendChild(courseNomralProgress);

                        XmlElement courseNormalProgress1 = xmlDocument.CreateElement("NormalSekundaProgress");
                        courseNormalProgress1.InnerText="1";
                        courseNomralProgress.AppendChild(courseNormalProgress1);

                        XmlElement courseNormalProgress2 = xmlDocument.CreateElement("NormalTercjaProgress");
                        courseNormalProgress2.InnerText="0";
                        courseNomralProgress.AppendChild(courseNormalProgress2);

                        XmlElement courseNormalProgress3 = xmlDocument.CreateElement("NormalKwaKwiProgress");
                        courseNormalProgress3.InnerText="0";
                        courseNomralProgress.AppendChild(courseNormalProgress3);

                        XmlElement courseNormalProgress4 = xmlDocument.CreateElement("NormalSekstaProgress");
                        courseNormalProgress4.InnerText="0";
                        courseNomralProgress.AppendChild(courseNormalProgress4);

                        XmlElement courseNormalProgress5 = xmlDocument.CreateElement("NormalSeptymaProgress");
                        courseNormalProgress5.InnerText="0";
                        courseNomralProgress.AppendChild(courseNormalProgress5);

                        XmlElement courseNormalProgress6 = xmlDocument.CreateElement("NormalPrySekProgress");
                        courseNormalProgress6.InnerText="0";
                        courseNomralProgress.AppendChild(courseNormalProgress6);

                        XmlElement courseNormalProgress7 = xmlDocument.CreateElement("NormalTerKwaProgress");
                        courseNormalProgress7.InnerText="0";
                        courseNomralProgress.AppendChild(courseNormalProgress7);

                        XmlElement courseNormalProgress8 = xmlDocument.CreateElement("NormalKwiSekProgress");
                        courseNormalProgress8.InnerText="0";
                        courseNomralProgress.AppendChild(courseNormalProgress8);

                        XmlElement courseNormalProgress9 = xmlDocument.CreateElement("NormalSepOktProgress");
                        courseNormalProgress9.InnerText="0";
                        courseNomralProgress.AppendChild(courseNormalProgress9);

                    #endregion
                
                    #region CourseHard
                    XmlElement courseHardProgress = xmlDocument.CreateElement("HardCourseProgress");
                    courseProgress.AppendChild(courseHardProgress);

                        XmlElement courseHardProgress1 = xmlDocument.CreateElement("HardUnoProgress");
                        courseHardProgress1.InnerText="1";
                        courseHardProgress.AppendChild(courseHardProgress1);

                        XmlElement courseHardProgress2 = xmlDocument.CreateElement("HardDosProgress");
                        courseHardProgress2.InnerText="0";
                        courseHardProgress.AppendChild(courseHardProgress2);

                        XmlElement courseHardProgress3 = xmlDocument.CreateElement("HardTresProgress");
                        courseHardProgress3.InnerText="0";
                        courseHardProgress.AppendChild(courseHardProgress3);
                    #endregion

                    #region CourseHardcore
                    XmlElement courseHardcoreProgress = xmlDocument.CreateElement("HardcoreCourseProgress");
                    courseProgress.AppendChild(courseHardcoreProgress);

                        XmlElement courseHardcoreProgress1 = xmlDocument.CreateElement("HardcoreIchiProgress");
                        courseHardcoreProgress1.InnerText="1";
                        courseHardcoreProgress.AppendChild(courseHardcoreProgress1);

                        XmlElement courseHardcoreProgress2 = xmlDocument.CreateElement("HardcoerNiProgress");
                        courseHardcoreProgress2.InnerText="0";
                        courseHardcoreProgress.AppendChild(courseHardcoreProgress2);
                    #endregion

                #endregion

                #region LevelsProgress
                XmlElement levelProgress = xmlDocument.CreateElement("LevelsProgress");
                root.AppendChild(levelProgress);

                    XmlElement levelEasyProgress = xmlDocument.CreateElement("EasyLevelProgress");
                    levelEasyProgress.InnerText="1";
                    levelProgress.AppendChild(levelEasyProgress);

                    XmlElement levelNormalProgress = xmlDocument.CreateElement("NormalLevelProgress");
                    levelNormalProgress.InnerText="0";
                    levelProgress.AppendChild(levelNormalProgress);

                    XmlElement levelHardProgress = xmlDocument.CreateElement("HardLevelProgress");
                    levelHardProgress.InnerText="0";
                    levelProgress.AppendChild(levelHardProgress);

                    XmlElement levelHardcoreProgress = xmlDocument.CreateElement("HardcoreLevelProgress");
                    levelHardcoreProgress.InnerText="0";
                    levelProgress.AppendChild(levelHardcoreProgress);

                #endregion

                #region Achievments
                XmlElement achievments = xmlDocument.CreateElement("Achievments");
                root.AppendChild(achievments);
                #endregion

            xmlDocument.AppendChild(root);

            xmlDocument.Save(Application.dataPath + "/Data.txt");

            if(File.Exists(Application.dataPath + "/Data.txt"))
            {
                Debug.Log("XML FILE SAVED" + Application.dataPath);
            }
    }
}
