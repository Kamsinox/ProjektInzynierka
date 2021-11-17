using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;
using TMPro;

public class ShopSystem : MonoBehaviour
    {
    // index itemu będzie musiał zgadzać się z przekazywanym id w fukncji buyItem(id)
    // np. item nr 5 będzie usunięty gdy item w sklepie z wpisanym 5 będzie kliknięty    
    public GameObject[] items;

    [SerializeField] TMP_Text scoreTxt;

    void Start()
    {
        checkAlreadyBoughtItems();
        checkOthersIfAvailable();
    }

    private void checkAlreadyBoughtItems()
    {
        //tworzymy listę z nazwami sprietów
        List<string> nazwy = new List<string>();

        string filePath = Application.dataPath + "/Data.txt";
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(filePath);

        XmlNodeList list = xmlDocument.GetElementsByTagName("ProfileImages");
        foreach(XmlNode x in list[0].ChildNodes)
        {
            //dodajemy do listy każdy Image z pliku XML
            nazwy.Add(x.InnerText);
        }

        for(int j=0; j<items.Length; j++)
        {
            for (int i=0; i<nazwy.Count; i++)
            {
                //pobranie nazwy buttona z unity
                string imageName = items[j].GetComponentInChildren<Button>().GetComponent<Image>().sprite.name;
                if(imageName == nazwy[i])
                {
                    destroyItem(j);
                    Debug.Log("Znazłem to samo dla i="+i+", j="+j);
                }
            }
        }
    }

    
    public void buyItem(int id) //tutaj podajemy odpowiedni id itemu
    {
        if(checkIfAvailable(id))
        {
            updateCoins(id);
            saveToXML(id);
            destroyItem(id);
        }
        checkOthersIfAvailable();
    }
    
    private bool checkIfAvailable(int id)
    {
        //sprawdzamy ile mamy w momencie kupowania monet...
        int beforeBuying = int.Parse(loadCoins());

        //...oraz ile kosztuje item, który chcemy kupić
        int price = int.Parse(items[id].GetComponentInChildren<TextMeshProUGUI>().text);

        if (beforeBuying >= price)
        {
            return true;
        }
        else return false;
    }

    private void saveToXML(int id)
    {
        //zapisywanie do xml nazwy buttonów do Image

        string imageName = items[id].GetComponentInChildren<Button>().GetComponent<Image>().sprite.name;
        Debug.Log("Zapisano do pliku: "+imageName);

        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList profileImageTag = xmlDocument.GetElementsByTagName("ProfileImages");
            XmlElement profileImage = xmlDocument.CreateElement("Image");
            profileImage.InnerText = imageName;
            profileImageTag[0].AppendChild(profileImage);

            xmlDocument.Save(filePath);
        }
        else Debug.Log("FILE NOT SAVED" + filePath);
    }

    private void checkOthersIfAvailable()
    {
        //zmiana kolorów na żółty jeżeli można kupić i czerwony jeżeli brakuje monet
        for(int i=0; i<items.Length; i++)
        {
            if(checkIfAvailable(i))
            {
                items[i].GetComponentInChildren<TextMeshProUGUI>().color = new Color(255, 255, 0, 255);
            }
            else
            {
                items[i].GetComponentInChildren<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            }
        }
    }

    private void updateCoins(int id)
    {
        //aktualizowanie ilości monet i zapisywanie od razu do pliku
        //plus zmiana tekstu ilości monet w profliu

        int beforeBuying = int.Parse(loadCoins());
        int price = int.Parse(items[id].GetComponentInChildren<TextMeshProUGUI>().text);
        int newScore = beforeBuying - price;


        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList coins = xmlDocument.GetElementsByTagName("Coins");
            coins[0].InnerText = newScore.ToString();

            scoreTxt.text = string.Format("Monety: {0}",(newScore.ToString()));

            xmlDocument.Save(filePath);

        }
        else Debug.Log("Failed to Save Coins" + filePath);

    }

    private void destroyItem(int id)
    {
        //BANG!!!

        Destroy(items[id]);
    }   

    private string loadCoins()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            //szukamy po tagu w pliku
            XmlNodeList coins = xmlDocument.GetElementsByTagName("Coins");

            //pobieramy szukaną zmienną i zamieniamy na string
            string text = coins[0].InnerText.ToString();

            return text;
        }
        else 
        {
            Debug.Log("FILE NOT LOADED" + filePath);
            return null;
        }
    }
}
