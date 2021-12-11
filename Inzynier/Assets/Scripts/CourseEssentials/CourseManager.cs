using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Xml;
using System.IO;

public class CourseManager : MonoBehaviour
{
    //NAZWY POZIOMÓW (czyli obiektów levels) MA ZNACZENIE
    //MUSZĄ BYĆ NAZWANE W ODPOWIEDNI SPOSÓB, INACZEJ KURS NIE ZADZIAŁA
    public GameObject[] levels; // liczba poziomów dla danego kursu

    public int courseLength;    // ile leveli będzie w danym kursie
    [SerializeField] TMP_Text courseProgessText; //gdzie będzie pokazywany postęp kursu

    [Space]
    public int addHowManyPoints;    //ile punktów dostanie się za poprawną odpowiedź
    public int multiplier;  //mnożnik punktów
    public GameObject textWrong; // tekst który wyświetla komunikat, przy błędnej odpowiedzi
        
    [Space]
    public GameObject endLevel;  // ostani ekran / podsumowanie
    [SerializeField] TMP_Text finalScoreText;   // gdzie wyświetlany będzie wynik



    SpirteAudioClipManager skryptSpriteAudio;

    // liczniki do kolejnych poziomów
    private bool ifPrevWasWrong;    //sprawdzanie czy odpowiedź była błędna
    private int goodAnswers;    //iloć poprawnych odpowiedzi
    private int courseProgess;  //liczenie progresu podczas kursu

    private int finalScore;     // obliczamy końcowy wynik jako int
    private int highscoreInt;    //  highscore w werji int
    private List<int> levelHighScores = new List<int>();    // lista najwyższych wyników
    private List<string> levelNames = new List<string>();   // przechowujemy tutaj listę złożoną z nazw poziomów
   
    private int currentLevelId;     //zapisywanie id do wyświetlenia obecnego levelu
    private int previousLevelId;    //zapisywanie poprzedniego levelu


    public static int courseID;
    public static int currentCourse;


    void Start()
    {
        goodAnswers = 0;
        courseProgess = 0;
        loadListOfLevels();
        levelManager();
    }

    #region XMLFun
    private void saveByXML()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            //pobieramy node (jako że "node" jest podstawą, a "element" jest elementem "nodea")
            //szukamy po tagu "Coins"
            XmlNodeList coins = xmlDocument.GetElementsByTagName("Coins");

            //tutaj szukamy po tagu "AllCoins"
            XmlNodeList allCoins = xmlDocument.GetElementsByTagName("AllCoins");

            //wybieramy pierwszy element z listy coins (jako że jest tylko jeden więc tylko 0)
            //i podstawaimy tą wartość pod inta żeby...
            int licznik = int.Parse(coins[0].InnerText);
            int licznik2 = int.Parse(allCoins[0].InnerText);

            //.. móc potem dodać nasz wynik do niego...
            licznik += finalScore;
            licznik2 += finalScore;
            
            //... i zapisać nowy wynik z powrotem do pliku do naszego wybranego elementu
            coins[0].InnerText = licznik.ToString();
            allCoins[0].InnerText = licznik2.ToString();

            //zapisanie dokumentu
            xmlDocument.Save(filePath);

            //Achievment (tam też jest zapisanie dokumentu)
            AchievmentsManager.achievmentsManagerInstance.addAchievmentProgress("4",finalScore);
            AchievmentsManager.achievmentsManagerInstance.addAchievmentProgress("5",finalScore);
        }
        else Debug.Log("FILE NOT SAVED" + filePath);
    }
    
    private void levelProgressSave()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            XmlNodeList courses = null; 

            switch(courseID)
            {
                case 1: 
                    courses = xmlDocument.GetElementsByTagName("EasyCourseProgress");
                    if(courses[0].ChildNodes.Count > currentCourse+1) 
                        courses[0].ChildNodes[currentCourse+1].InnerText = "1";
                    else
                    {
                        courses = xmlDocument.GetElementsByTagName("LevelsProgress");
                        courses[0].ChildNodes[courseID].InnerText = "1";
                    }
                break;

                case 2: 
                    courses = xmlDocument.GetElementsByTagName("NormalCourseProgress");
                    if(courses[0].ChildNodes.Count > currentCourse+1) 
                        courses[0].ChildNodes[currentCourse+1].InnerText = "1";
                    else
                    {
                        courses = xmlDocument.GetElementsByTagName("LevelsProgress");
                        courses[0].ChildNodes[courseID].InnerText = "1";
                    }
                break;

                case 3: 
                    courses = xmlDocument.GetElementsByTagName("HardCourseProgress");
                    if(courses[0].ChildNodes.Count > currentCourse+1) 
                        courses[0].ChildNodes[currentCourse+1].InnerText = "1";
                    else
                    {
                        courses = xmlDocument.GetElementsByTagName("LevelsProgress");
                        courses[0].ChildNodes[courseID].InnerText = "1";
                    }
                break;

                case 4: 
                    courses = xmlDocument.GetElementsByTagName("HardcoreCourseProgress");
                    if(courses[0].ChildNodes.Count > currentCourse+1) 
                        courses[0].ChildNodes[currentCourse+1].InnerText = "1";
                break;

                default: Debug.Log("Błąd przy wybieraniu idCourse w progressCourse"); break;
            }

            xmlDocument.Save(filePath);
        }
        else Debug.Log("FILE NOT SAVED dla levelProgressSave" + filePath);
            
    }
    #endregion

    private int setFinalScore()
    {
        finalScore = 0;
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            // switch w zależności który poziom trudności wybrano
            // courseId zmieniamy podczas wyboru kursu (w skrypcie)
            switch(courseID)
            {
                case 1:
                    //w zależności od wybranego kursu ustalamy highscore
                    switch(currentCourse)
                    {
                        case 0:
                            XmlNodeList highscoreEasyPryOkt = xmlDocument.GetElementsByTagName("EasyPrymaOktawa");
                            setFinalScoreinFinalScore(highscoreEasyPryOkt);
                        break;

                        case 1:
                            XmlNodeList highscoreEasySekunda = xmlDocument.GetElementsByTagName("EasySekunda");
                            setFinalScoreinFinalScore(highscoreEasySekunda);
                        break;

                        case 2:
                            XmlNodeList highscoreEasyTercja = xmlDocument.GetElementsByTagName("EasyTercja");
                            setFinalScoreinFinalScore(highscoreEasyTercja);
                        break;

                        case 3:
                            XmlNodeList highscoreEasyKwaKwi = xmlDocument.GetElementsByTagName("EasyKwaKwi");
                            setFinalScoreinFinalScore(highscoreEasyKwaKwi);
                        break;

                        case 4:
                            XmlNodeList highscoreEasySeksta = xmlDocument.GetElementsByTagName("EasySeksta");
                            setFinalScoreinFinalScore(highscoreEasySeksta);
                        break;

                        case 5:
                            XmlNodeList highscoreSeptyma = xmlDocument.GetElementsByTagName("EasySeptyma");
                            setFinalScoreinFinalScore(highscoreSeptyma);
                        break;
              

                        default:
                            Debug.Log("Blady przy ladowaniu id kursu easy");
                        break;
                    }
                    break;

                case 2: 
                    switch(currentCourse)
                    {
                        case 0:
                            XmlNodeList highscoreNormalSek = xmlDocument.GetElementsByTagName("NormalSekunda");
                            setFinalScoreinFinalScore(highscoreNormalSek);
                        break;

                        case 1:
                            XmlNodeList highscoreNormalTer = xmlDocument.GetElementsByTagName("NormalTercja");
                            setFinalScoreinFinalScore(highscoreNormalTer);
                        break;

                        case 2:
                            XmlNodeList highscoreNormalKwaKwi = xmlDocument.GetElementsByTagName("NormalKwaKwi");
                            setFinalScoreinFinalScore(highscoreNormalKwaKwi);
                        break;

                        case 3:
                            XmlNodeList highscoreNormalSeksta = xmlDocument.GetElementsByTagName("NormalSeksta");
                            setFinalScoreinFinalScore(highscoreNormalSeksta);
                        break;

                        case 4:
                            XmlNodeList highscoreNormalSep = xmlDocument.GetElementsByTagName("NormalSeptyma");
                            setFinalScoreinFinalScore(highscoreNormalSep);
                        break;

                        case 5:
                            XmlNodeList highscoreNormalPrySek = xmlDocument.GetElementsByTagName("NormalPrySek");
                            setFinalScoreinFinalScore(highscoreNormalPrySek);
                        break;

                        case 6:
                            XmlNodeList highscoreNormalTerKwa = xmlDocument.GetElementsByTagName("NormalTerKwa");
                            setFinalScoreinFinalScore(highscoreNormalTerKwa);
                        break;

                        case 7:
                            XmlNodeList highscoreNormalKwiSek = xmlDocument.GetElementsByTagName("NormalKwiSek");
                            setFinalScoreinFinalScore(highscoreNormalKwiSek);
                        break;

                        case 8:
                            XmlNodeList highscoreNormalSepOpt = xmlDocument.GetElementsByTagName("NormalSepOkt");
                            setFinalScoreinFinalScore(highscoreNormalSepOpt);
                        break;

                        default:
                            Debug.Log("Blady przy ladowaniu id kursu normal");
                        break;

                    }
                    break;

                case 3:
                    switch(currentCourse)
                    {
                        case 0:
                            XmlNodeList highscoreHard1 = xmlDocument.GetElementsByTagName("HardUno");
                            setFinalScoreinFinalScore(highscoreHard1);
                        break;

                        case 1:
                            XmlNodeList highscoreHard2 = xmlDocument.GetElementsByTagName("HardDos");
                            setFinalScoreinFinalScore(highscoreHard2);
                        break;

                        case 2:
                            XmlNodeList highscoreHard3 = xmlDocument.GetElementsByTagName("HardTres");
                            setFinalScoreinFinalScore(highscoreHard3);
                        break;

                        default:
                            Debug.Log("Blady przy ladowaniu id kursu hard");
                        break;
                    }
                break;

                case 4:
                    switch(currentCourse)
                    {
                        case 0:
                            XmlNodeList highscoreHardcore1 = xmlDocument.GetElementsByTagName("HardcoreIchi");
                            setFinalScoreinFinalScore(highscoreHardcore1);
                        break;

                        case 1:
                            XmlNodeList highscoreHardcore2 = xmlDocument.GetElementsByTagName("HardcoerNi");
                            setFinalScoreinFinalScore(highscoreHardcore2);
                        break;

                        default:
                            Debug.Log("Blady przy ladowaniu id kursu hardcore");
                        break;
                    }
                break;

                default: 
                    Debug.Log("Blad przy ladowaniu idTrudnosci kursu"); 
                break;
            }

            xmlDocument.Save(filePath);
            
            //zabezpieczenie przed dodaniem ujemnego wyniku do postępu osiągnięcia
            if(goodAnswers - highscoreInt >= 0)
            AchievmentsManager.achievmentsManagerInstance.addAchievmentProgress((courseID-1).ToString(),goodAnswers-highscoreInt);
        }
        else Debug.Log("FILE NOT SAVED przy finalScore" + filePath);

        return finalScore;    
    }

    private void setFinalScoreinFinalScore(XmlNodeList nodeList)
    {
        //ustawiamy highscore z pliku XML
        highscoreInt = int.Parse(nodeList[0].InnerText.ToString());

        //jeżeli liczba poprawnych odpowiedzi będzie większa od rekordu
        if(goodAnswers > highscoreInt)
        {
        // finał = (rekord * ilePunktówZaPorawnąOdpowiedź) + ((ilośćPoprawnychOdp - rekord) * ilePZPO * mnożnikPunktów);
        // np. rekord = 4, poprawneodpowiedzi = 5, mnożnik=3, ilePZPO=10
        // finał = (4 * 10) + (5 - 4) * 10 * 3
        // finał = 40 + 30
        // finał = 70
        finalScore = (highscoreInt * addHowManyPoints) + ((goodAnswers - highscoreInt) * addHowManyPoints * multiplier);
        nodeList[0].InnerText = goodAnswers.ToString();
        
        }

        //jeżeli liczba poprawnych odpowiedzi będzie mniejsza lub równa rekordowi
        else finalScore = goodAnswers * addHowManyPoints;
    }


    #region searchForLevel_()
    public void searchForLevelPryma()
    {
        skryptSpriteAudio = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<SpirteAudioClipManager>();
        skryptSpriteAudio.randomLevelPryma();
    }

    public void searchForLevelSekundaMala()
    {
        skryptSpriteAudio = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<SpirteAudioClipManager>();
        skryptSpriteAudio.randomLevelSekundaMala();
    }

    public void searchForLevelSekundaWielka()
    {
        skryptSpriteAudio = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<SpirteAudioClipManager>();
        skryptSpriteAudio.randomLevelSekundaWielka();
    }

    public void searchForLevelTercjaMala()
    {
        skryptSpriteAudio = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<SpirteAudioClipManager>();
        skryptSpriteAudio.randomLevelTercjaMala();
    }

    public void searchForLevelTercjaWielka()
    {
        skryptSpriteAudio = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<SpirteAudioClipManager>();
        skryptSpriteAudio.randomLevelTercjaWielka();
    }

    public void searchForLevelKwarta()
    {
        skryptSpriteAudio = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<SpirteAudioClipManager>();
        skryptSpriteAudio.randomLevelKwarta();
    }

    public void searchForLevelKwinta()
    {
        skryptSpriteAudio = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<SpirteAudioClipManager>();
        skryptSpriteAudio.randomLevelKwinta();
    }

    public void searchForLevelSekstaMala()
    {
        skryptSpriteAudio = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<SpirteAudioClipManager>();
        skryptSpriteAudio.randomLevelSekstaMala();
    }

    public void searchForLevelSekstaWielka()
    {
        skryptSpriteAudio = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<SpirteAudioClipManager>();
        skryptSpriteAudio.randomLevelSekstaWielka();
    }

    public void searchForLevelSeptymaMala()
    {
        skryptSpriteAudio = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<SpirteAudioClipManager>();
        skryptSpriteAudio.randomLevelSeptymaMala();
    }

    public void searchForLevelSeptymaWielka()
    {
        skryptSpriteAudio = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<SpirteAudioClipManager>();
        skryptSpriteAudio.randomLevelSeptymaWielka();
    }
    
    public void searchForLevelOktawa()
    {
        skryptSpriteAudio = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<SpirteAudioClipManager>();
        skryptSpriteAudio.randomLevelOktawa();
    }
    
    #endregion


    private void loadListOfLevels()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            //wyszukiwanie wszystkich nazw poziomów w kursie
            levelNames.Add(levels[i].name);
        }
    }

    private void showLevel(int i)
    {
        if(courseProgess != courseLength)
        {
            switch(levelNames[i])
            {
                case "LevelPryma":
                    loadLevel();
                    searchForLevelPryma();
                    break;

                case "LevelSekundaMala":
                    loadLevel();
                    searchForLevelSekundaMala();
                    break;

                case "LevelSekundaWielka":
                    loadLevel();
                    searchForLevelSekundaWielka();
                    break;

                case "LevelTercjaMala":
                    loadLevel();
                    searchForLevelTercjaMala();
                    break;

                case "LevelTercjaWielka":
                    loadLevel();
                    searchForLevelTercjaWielka();
                    break;

                case "LevelKwarta":
                    loadLevel();
                    searchForLevelKwarta();
                    break;

                case "LevelKwinta":
                    loadLevel();
                    searchForLevelKwinta();
                    break;

                case "LevelSekstaMala":
                    loadLevel();
                    searchForLevelSekstaMala();
                    break;

                case "LevelSekstaWielka":
                    loadLevel();
                    searchForLevelSekstaWielka();
                    break;
                    
                case "LevelSeptymaMala":
                    loadLevel();
                    searchForLevelSeptymaMala();
                    break;

                case "LevelSeptymaWielka":
                    loadLevel();
                    searchForLevelSeptymaWielka();
                    break;

                case "LevelOktawa":
                    loadLevel();
                    searchForLevelOktawa();
                    break;

                default:
                    Debug.Log("Wystąpił błąd podczas szukania nazwy poziomu");
                    break;
            }
        }
        else loadLevel();
        
    }

    public void levelManager()
    {   
        previousLevelId = currentLevelId;
        currentLevelId = Random.Range(0,levelNames.Count);
        showLevel(currentLevelId);    
    }

    public void loadLevel()
    {
        textWrong.SetActive(false); //wyłączanie komunikatu błędnej odpowiedzi

        if (courseProgess == 0)
        {
            levels[currentLevelId].SetActive(true);
            SetProgressText(courseProgessText, courseProgess + 1);
        }

        else if (courseProgess != courseLength)
        {
            levels[previousLevelId].SetActive(false);
            levels[currentLevelId].SetActive(true);

            //wyświetlanie progressu w kursie
            SetProgressText(courseProgessText, courseProgess + 1);
        }

        else
        {
            endLevel.SetActive(true);
            levels[previousLevelId].SetActive(false);
            courseProgessText.text = null;

            //wyświetlanie wyniku
            SetScoreText(finalScoreText, setFinalScore());

            //zapisywanie do XML
            levelProgressSave();
            saveByXML();
        }
    }

    public void goodAnswer()
    {
        courseProgess++;
        scoreCount();
        levelManager();
    }

    public void wrongAnswer()
    {
        ifPrevWasWrong = true;  //blokada zdobywania punktow
        textWrong.SetActive(true);
    }

    public void scoreCount()
    {
        if (!ifPrevWasWrong) 
        {
            goodAnswers++;
        }
        else ifPrevWasWrong = false;
    }


    public void SetScoreText(TMP_Text textMesh, int score)
    {
        //ustawianie wyświetlania wyniku i punktów
        textMesh.text = string.Format("Twój wynik: {0}/{1} \n Otrzymujesz + {2} monet", (goodAnswers), (courseLength), (score)); 
    }

    public void SetProgressText(TMP_Text textMesh, int progressScore)
    {
        //ustawianie progressu kursu
        textMesh.text = string.Format("{0}/{1}", (progressScore), (courseLength)); 
    }

}
