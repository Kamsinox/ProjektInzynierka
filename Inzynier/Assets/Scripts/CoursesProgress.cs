using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;


public class CoursesProgress : MonoBehaviour
{
    public Button[] coursesBtn;
    public int idCourse;

    void Start()
    {
        progressCourse();
    }

    private void progressCourse()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            XmlNodeList courses = null; 

            switch(idCourse)
            {
                case 1: 
                    courses = xmlDocument.GetElementsByTagName("EasyCourseProgress");
                break;

                case 2: 
                    courses = xmlDocument.GetElementsByTagName("NormalCourseProgress");
                break;

                case 3: 
                    courses = xmlDocument.GetElementsByTagName("HardCourseProgress");
                break;

                case 4: 
                    courses = xmlDocument.GetElementsByTagName("HardcoreCourseProgress");
                break;

                default: Debug.Log("Błąd przy wybieraniu idCourse w progressCourse"); break;
            }

            for(int i=0; i<courses[0].ChildNodes.Count; i++)
            {
                if(courses[0].ChildNodes[i].InnerText == "1")
                {
                    coursesBtn[i].interactable = true;
                }
                else coursesBtn[i].interactable = false;
            }
        }
        else Debug.Log("FILE NOT LOADED for progressCourse" + filePath);
    }
}
