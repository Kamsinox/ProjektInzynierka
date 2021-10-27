using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Xml;
using System.IO;

public class EasyCourseManager : MonoBehaviour
{
    //NAZWY POZIOMÓW (czyli obiektów levels) MA ZNACZENIE
    //MUSZĄ BYĆ NAZWANE W ODPOWIEDNI SPOSÓB, INACZEJ KURS NIE ZADZIAŁA
    public GameObject[] levels; // liczba poziomów dla danego kursu

    public int courseLength;    // ile leveli będzie w danym kursie
    [SerializeField] TMP_Text courseProgessText; //gdzie będzie pokazywany postęp kursu

    [Space]
    public GameObject textWrong; // tekst który wyświetla komunikat, przy błędnej odpowiedzi
        
    [Space]
    public GameObject endLevel;  // ostani ekran / podsumowanie
    [SerializeField] TMP_Text finalScoreText;   // gdzie wyświetlany będzie wynik
    


    SpirteAudioClipManager skryptSpriteAudio;

    // liczniki do kolejnych poziomów
    private bool ifPrevWasWrong;    //sprawdzanie czy odpowiedź była błędna
    private int goodAnswers;    //tabela z kursami, które już zostały dobrze zrobione
    private int courseProgess;  //liczenie progresu podczas kursu

    private int coinsAll;   //licznik monet
    private int finalScore = 0;     // obliczamy końcowy wynik jako int
    private List<int> levelHighScores = new List<int>();    // lista najwyższych wyników
    private List<string> levelNames = new List<string>();   // przechowujemy tutaj listę złożoną z nazw poziomów
   
    private int currentLevelId;     //zapisywanie id do wyświetlenia obecnego levelu
    private int previousLevelId;    //zapisywanie poprzedniego levelu

    void Start()
    {
        goodAnswers = 0;
        courseProgess = 0;
        loadListOfLevels();
        levelManager();
        loadByXML();
        
        Debug.Log("wybrano kurs nr: " + ManagerScenes.currentCourse);
        
        // dos = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/ScaleImages/TwoNotes/CourseEasy/Kwinta/Level_1_3.png", typeof(Sprite));
        // uno = Resources.Load <Sprite> ("Assets/ScaleImages/TwoNotes/CourseEasy/Kwinta/Level_1_1.png");
    }

    private PlayerStats save()
    {
        PlayerStats stats = new PlayerStats();

        stats.coins = coinsAll;

        return stats;
    }


    private void saveByXML()
    {
        PlayerStats stats = save();
        XmlDocument xmlDocument = new XmlDocument();

        #region Create XMLDocument Element
        XmlElement root = xmlDocument.CreateElement("Save");
        root.SetAttribute("FileName", "Staty");

        //zapisywanie monet do XML
        XmlElement coinsElement = xmlDocument.CreateElement("Coins");
        coinsAll += finalScore;
        coinsElement.InnerText = coinsAll.ToString();
        root.AppendChild(coinsElement);

        //zapisanie highscore

        #endregion

        xmlDocument.AppendChild(root);
        xmlDocument.Save(Application.dataPath + "/Data.txt");

        if(File.Exists(Application.dataPath + "/Data.txt"))
        {
            Debug.Log("XML FILE SAVED" + Application.dataPath);
        }
    }

    private void loadByXML()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            PlayerStats stats = new PlayerStats();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            #region Get data from file
            //load ilość monet
            XmlNodeList coins = xmlDocument.GetElementsByTagName("Coins");
            coinsAll = int.Parse(coins[0].InnerText);
            stats.coins = coinsAll;

            //load highcores
            #endregion

        }
        else Debug.Log("FILE NOT SAVED" + filePath);
    }

    private void setHighScore(int currentCourse, int currentScore)
    {
        if(currentScore > levelHighScores[currentCourse])
        {
            levelHighScores[currentCourse] = currentScore;
        }
        Debug.Log("Max dla kursu: "+currentScore+" wynosi: "+levelHighScores[currentCourse]);
    }


    #region searchForLevel_()
    //odpalanie funkcji z innego skryptu
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
            //Debug.Log(i + ". Znalazlem taki obiekt: " + levelNames[i]);
        }
    }

    private void showLevel(int i)
    {
        //Debug.Log("W momencie wywoływania manager level currentLevel to: " + currentLevel);
        //Debug.Log("Dlugosc listy nazw = " + levelNames.Count);

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
            //Debug.Log("Level nr " + currentLevel + ", wynik = " + finalScore);
            levels[currentLevelId].SetActive(true);

            //wyświetlanie progressu w kursie
            SetProgressText(courseProgessText, courseProgess + 1);
        }

        else
        {
            //Debug.Log("Koncowy wynik = " + finalScore);
            endLevel.SetActive(true);
            levels[previousLevelId].SetActive(false);
            courseProgessText.text = null;

            //int y = ChangeSceneManager.currentCourse;
            //setHighScore(y, goodAnswers);

            //wyświetlanie wyniku
            SetScoreText(finalScoreText, finalScore);
            saveByXML();
        }
    }

    public void goodAnswer()
    {
        courseProgess++;
        scoreCount();
        //Debug.Log("Liczba dobrych odpowiedzi: " + goodAnswers);
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
            finalScore = finalScore + 20;
        }
        else ifPrevWasWrong = false;

        //przydzielanie punktów
        //jeżeli poprzednia odpowiedź była zła to brak
        //jeżeli dobra odpowiedź to +20 pkt.
        //jeżeli dobra odpowiedź już była +5 pkt.

        /*if (!ifPrevWasWrong)
        {
            goodAnswers++;

            if (goodAnswersMax < goodAnswers)
            {
                finalScore = finalScore + 20;
            }
            else
            {
                finalScore = finalScore + 5;
            }
        }
        else ifPrevWasWrong = false;*/
    }

    public void SetScoreText(TMP_Text textMesh, int score)
    {
        textMesh.text = string.Format("Twój wynik: {0}/{1} \n Otrzymujesz + {2} monet", (goodAnswers), (courseLength), (score)); //ustawianie wyświetlania wyniku i punktów
    }

    public void SetProgressText(TMP_Text textMesh, int progressScore)
    {
        textMesh.text = string.Format("{0}/{1}", (progressScore), (courseLength)); //ustawianie progressu kursu
    }

}
