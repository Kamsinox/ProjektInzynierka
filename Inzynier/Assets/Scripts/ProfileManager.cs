using TMPro;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    private string text;

    public GameObject profileImage;
    public GameObject backgroundImage;
    public GameObject frameImage;

    [Space]
    [SerializeField] TMP_Text scoreTxt;
    void Start()
    {
        loadScore();
        loadProfileImage();
        loadBackground();
        loadFrame();
    }

    private void loadScore()
    {
        //ścieżka do pliku z danymi
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            //załadowanie pliku
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            //szukamy po tagu w pliku
            XmlNodeList coins = xmlDocument.GetElementsByTagName("Coins");

            //pobieramy szukaną zmienną i zamieniamy na string
            text = coins[0].InnerText.ToString();

            //wyświetlanie do odpowiedniego gameobject na scenie
            scoreTxt.text = string.Format("Monety: {0}",(text));
            
            /*
            //może się przydać
            foreach (TMP_Text texty in scoreTxt)
            {
                string newText = texty.GetComponent<TMPro.TextMeshProUGUI>().text;
                newText = string.Format("Monety: {0}",(text));
                texty.text = newText;
            }
            */
        }
        else Debug.Log("FILE NOT SAVED" + filePath);
    }

    private void loadProfileImage()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList profileImageElement = xmlDocument.GetElementsByTagName("CurrentProfileImage");
            text = profileImageElement[0].InnerText.ToString();
            //Debug.Log("Nazwa image profilu: "+text);

            //pobieranie tablicy wszystkich assetów znajdujących się w pliku resources/profileimages
            Object[] data = Resources.LoadAll("ProfileImages",typeof(Sprite));

            for(int i=0; i<data.Length; i++)
            { 
                //przeszukujemy całą tablicę, dopóki nie znajdziemy odpowiedniej nazwy
                //dzięki czemu możemy potem zamienić image
                if(text == data[i].name)
                {
                    Image newSprite = profileImage.GetComponent<Image>();
                    newSprite.sprite = (Sprite)data[i];
                }
            }
        }
    }

    private void loadBackground()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList backgroundElement = xmlDocument.GetElementsByTagName("CurrentBackground");
            text = backgroundElement[0].InnerText.ToString();
            //Debug.Log("Nazwa background: "+text);

            Object[] data = Resources.LoadAll("Backgrounds",typeof(Sprite));
            for(int i=0; i<data.Length; i++)
            { 
                if(text == data[i].name)
                {
                    Image newSprite = backgroundImage.GetComponent<Image>();
                    newSprite.sprite = (Sprite)data[i];
                }
            }
        }
    }

    private void loadFrame()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList frameElement = xmlDocument.GetElementsByTagName("CurrentFrame");
            text = frameElement[0].InnerText.ToString();
            //Debug.Log("Nazwa frame: "+text);

            Object[] data = Resources.LoadAll("Frames",typeof(Sprite));
            for(int i=0; i<data.Length; i++)
            { 
                if(text == data[i].name)
                {
                    Image newSprite = frameImage.GetComponent<Image>();
                    newSprite.sprite = (Sprite)data[i];
                }
            }
        }
    }

    public void changeProfile(Image newImage)
    {
        Image newSprite = profileImage.GetComponent<Image>();
        newSprite.sprite = newImage.sprite;
        Debug.Log("Nazwa nowego profilu: "+newImage.sprite.name);

        string filePath = Application.dataPath + "/Data.txt";

        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList profileImage = xmlDocument.GetElementsByTagName("CurrentProfileImage");
            string profileImageName = newImage.sprite.name;
            profileImage[0].InnerText = profileImageName;

            xmlDocument.Save(filePath);
        }
        else Debug.Log("FILE NOT SAVED" + filePath);
    }

    public void changeBackground(Image newImage)
    {
        Image newSprite = backgroundImage.GetComponent<Image>();
        newSprite.sprite = newImage.sprite;
        Debug.Log("Nazwa backgroundu: "+newImage.sprite.name);

        string filePath = Application.dataPath + "/Data.txt";

        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList background = xmlDocument.GetElementsByTagName("CurrentBackground");
            string backgroundName = newImage.sprite.name;
            background[0].InnerText = backgroundName;

            xmlDocument.Save(filePath);
        }
        else Debug.Log("FILE NOT SAVED" + filePath);
    }

    public void changeFrame(Image newImage)
    {
        Image newSprite = frameImage.GetComponent<Image>();
        newSprite.sprite = newImage.sprite;
        Debug.Log("Nazwa frame: "+newImage.sprite.name);

        string filePath = Application.dataPath + "/Data.txt";

        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList frame = xmlDocument.GetElementsByTagName("CurrentFrame");
            string frameName = newImage.sprite.name;
            frame[0].InnerText = frameName;

            xmlDocument.Save(filePath);
        }
        else Debug.Log("FILE NOT SAVED" + filePath);
    }
}
