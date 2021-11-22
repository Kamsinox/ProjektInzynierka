using UnityEngine;
using System.Xml;
using System.IO;

public class CompleteCourseManager : MonoBehaviour
{
    // star musi być odnosić się do tego samego kursu...
    public GameObject[] star;
    // ... z którego jest highscore
    public int[] highscoresInt;

    public int idCourse;

    void Start()
    {
        checkIfCompleted();
    }

    private void checkIfCompleted()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            XmlNodeList highscores = null;

            switch(idCourse)
            {
                case 1: 
                    highscores = xmlDocument.GetElementsByTagName("EasyCourse");
                break;

                case 2: 
                    highscores = xmlDocument.GetElementsByTagName("NormalCourse");
                break;

                case 3: 
                    highscores = xmlDocument.GetElementsByTagName("HardCourse");
                break;

                case 4: 
                    highscores = xmlDocument.GetElementsByTagName("HardcoreCourse");
                break;

                default: Debug.Log("Błąd przy pokazywaniu gwiazdki za highscore"); break;
            }
           

            for(int i=0; i<highscores[0].ChildNodes.Count; i++)
            {
                if(highscores[0].ChildNodes[i].InnerText == highscoresInt[i].ToString())
                {
                    star[i].SetActive(true);
                }
                else star[i].SetActive(false);
            }
        }
        else Debug.Log("FILE NOT LOADED for complete courseManager" + filePath);
    }
}
