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
    public GameObject[] itemsProfile;

    [Space]
    public GameObject[] itemsBackground;

    [Space]
    public GameObject[] itemsFrame;

    [Space]
    [SerializeField] TMP_Text scoreTxt;

    void Start()
    {
        checkAlreadyBoughtItems();
        checkOtherProfilesIfAvailable();
        checkOtherBackgoundsIfAvailable();
        checkOtherFramesIfAvailable();
    }

    private void checkAlreadyBoughtItems()
    {
        //tworzymy listy z nazwami sprietów
        List<string> nazwyProfil = new List<string>();
        List<string> nazwyBackgorund = new List<string>();
        List<string> nazwyFrame = new List<string>();

        string filePath = Application.dataPath + "/Data.txt";
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(filePath);


        #region Czy ProifleImage juz kupiony
        XmlNodeList list1 = xmlDocument.GetElementsByTagName("ProfileImages");
        foreach(XmlNode x in list1[0].ChildNodes)
        {
            //dodajemy do listy każdy Image z pliku XML
            nazwyProfil.Add(x.InnerText);
        }

        for(int j=0; j<itemsProfile.Length; j++)
        {
            for (int i=0; i<nazwyProfil.Count; i++)
            {
                //pobranie nazwy buttona z unity
                string imageName = itemsProfile[j].GetComponentInChildren<Button>().GetComponent<Image>().sprite.name;
                if(imageName == nazwyProfil[i])
                {
                    destroyItem(j,1);
                    Debug.Log("Znazłem Image dla i="+i+", j="+j);
                }
            }
        }
        #endregion


        #region Czy Backgound juz kupiony
        XmlNodeList list2 = xmlDocument.GetElementsByTagName("Backgrounds");
        foreach(XmlNode x in list2[0].ChildNodes)
        {
            //dodajemy do listy każdy Background z pliku XML
            nazwyBackgorund.Add(x.InnerText);
        }

        for(int j=0; j<itemsBackground.Length; j++)
        {
            for (int i=0; i<nazwyBackgorund.Count; i++)
            {
                string backgroundName = itemsBackground[j].GetComponentInChildren<Button>().GetComponent<Image>().sprite.name;
                if(backgroundName == nazwyBackgorund[i])
                {
                    destroyItem(j,2);
                    Debug.Log("Znazłem Background dla i="+i+", j="+j);
                }
            }
        }
        #endregion


        #region Czy Frame juz kupiony
        XmlNodeList list3 = xmlDocument.GetElementsByTagName("ProfileFrames");
        foreach(XmlNode x in list3[0].ChildNodes)
        {
            //dodajemy do listy każdy Frame z pliku XML
            nazwyFrame.Add(x.InnerText);
        }

        for(int j=0; j<itemsFrame.Length; j++)
        {
            for (int i=0; i<nazwyFrame.Count; i++)
            {
                string frameName = itemsFrame[j].GetComponentInChildren<Button>().GetComponent<Image>().sprite.name;
                if(frameName == nazwyFrame[i])
                {
                    destroyItem(j,3);
                    Debug.Log("Znazłem Frame dla i="+i+", j="+j);
                }
            }
        }
        #endregion

    }

    #region ProfileImage buy and save
    public void buyShopItemProfile(int id) //tutaj podajemy odpowiedni id itemu
    {
        if(checkIfProfileAvailable(id))
        {
            updateCoins(id,1);
            saveToXMLItemProfile(id);
            destroyItem(id,1);
        }
        checkOtherProfilesIfAvailable();
        checkOtherBackgoundsIfAvailable();
        checkOtherFramesIfAvailable();
    }

    private bool checkIfProfileAvailable(int id)
    {
        //sprawdzamy ile mamy w momencie kupowania monet...
        int beforeBuying = int.Parse(loadCoins());

        //...oraz ile kosztuje item, który chcemy kupić
        int price = int.Parse(itemsProfile[id].GetComponentInChildren<TextMeshProUGUI>().text);

        if (beforeBuying >= price) return true;
        else return false;
    }

    private void saveToXMLItemProfile(int id)
    {
        //zapisywanie do xml nazwy buttonów do Image

        string imageName = itemsProfile[id].GetComponentInChildren<Button>().GetComponent<Image>().sprite.name;
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
    #endregion

    #region Backgound buy and save
    public void buyShopItemBackgound(int id)
    {
        if(checkIfBackgroundAvailable(id))
        {
            updateCoins(id,2);
            saveToXMLItemBackgound(id);
            destroyItem(id,2);
        }
        checkOtherProfilesIfAvailable();
        checkOtherBackgoundsIfAvailable();
        checkOtherFramesIfAvailable();
    }

    private bool checkIfBackgroundAvailable(int id)
    {
        //sprawdzamy ile mamy w momencie kupowania monet...
        int beforeBuying = int.Parse(loadCoins());

        //...oraz ile kosztuje item, który chcemy kupić
        int price = int.Parse(itemsBackground[id].GetComponentInChildren<TextMeshProUGUI>().text);

        if (beforeBuying >= price) return true;
        else return false;
    }

    private void saveToXMLItemBackgound(int id)
    {
        //zapisywanie do xml nazwy buttonów do Image

        string backgroundName = itemsBackground[id].GetComponentInChildren<Button>().GetComponent<Image>().sprite.name;
        Debug.Log("Zapisano do pliku: "+backgroundName);

        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList backgroundTag = xmlDocument.GetElementsByTagName("Backgrounds");
            XmlElement backgroundElement = xmlDocument.CreateElement("Background");
            backgroundElement.InnerText = backgroundName;
            backgroundTag[0].AppendChild(backgroundElement);

            xmlDocument.Save(filePath);
        }
        else Debug.Log("FILE NOT SAVED" + filePath);
    }
    #endregion

    #region Frame buy and save
    public void buyShopItemFrame(int id)
    {
        if(checkIfFrameAvailable(id))
        {
            updateCoins(id,3);
            saveToXMLItemFrame(id);
            destroyItem(id,3);
        }
        checkOtherProfilesIfAvailable();
        checkOtherBackgoundsIfAvailable();
        checkOtherFramesIfAvailable();
    }

    private bool checkIfFrameAvailable(int id)
    {
        //sprawdzamy ile mamy w momencie kupowania monet...
        int beforeBuying = int.Parse(loadCoins());

        //...oraz ile kosztuje item, który chcemy kupić
        int price = int.Parse(itemsFrame[id].GetComponentInChildren<TextMeshProUGUI>().text);

        if (beforeBuying >= price) return true;
        else return false;
    }

    private void saveToXMLItemFrame(int id)
    {
        //zapisywanie do xml nazwy buttonów do Image

        string frameName = itemsFrame[id].GetComponentInChildren<Button>().GetComponent<Image>().sprite.name;
        Debug.Log("Zapisano do pliku: "+frameName);

        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList profileFrameTag = xmlDocument.GetElementsByTagName("ProfileFrames");
            XmlElement profileFrame = xmlDocument.CreateElement("Frame");
            profileFrame.InnerText = frameName;
            profileFrameTag[0].AppendChild(profileFrame);

            xmlDocument.Save(filePath);
        }
        else Debug.Log("FILE NOT SAVED" + filePath);
    }
    #endregion
    


    private void checkOtherProfilesIfAvailable()
    {
        //zmiana kolorów na żółty jeżeli można kupić i czerwony jeżeli brakuje monet
        for(int i=0; i<itemsProfile.Length; i++)
        {
            if(itemsProfile[i] != null) // bez tego błąd, bo próbujemy zmieniać nieistniejący obiekt
            {
                if(checkIfProfileAvailable(i))
                {
                    itemsProfile[i].GetComponentInChildren<TextMeshProUGUI>().color = new Color(255, 255, 0, 255);
                }
                else
                {
                    itemsProfile[i].GetComponentInChildren<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
                }
            }
        }
    }

    private void checkOtherBackgoundsIfAvailable()
    {
        //zmiana kolorów na żółty jeżeli można kupić i czerwony jeżeli brakuje monet
        for(int i=0; i<itemsBackground.Length; i++)
        {
            if(itemsBackground[i] != null) // bez tego błąd, bo próbujemy zmieniać nieistniejący obiekt
            {
                if(checkIfBackgroundAvailable(i))
                {
                    itemsBackground[i].GetComponentInChildren<TextMeshProUGUI>().color = new Color(255, 255, 0, 255);
                }
                else
                {
                    itemsBackground[i].GetComponentInChildren<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
                }
            }
        }
    }

    private void checkOtherFramesIfAvailable()
    {
        //zmiana kolorów na żółty jeżeli można kupić i czerwony jeżeli brakuje monet
        for(int i=0; i<itemsFrame.Length; i++)
        {
            if(itemsFrame[i] != null) // bez tego błąd, bo próbujemy zmieniać nieistniejący obiekt
            {
                if(checkIfFrameAvailable(i))
                {
                    itemsFrame[i].GetComponentInChildren<TextMeshProUGUI>().color = new Color(255, 255, 0, 255);
                }
                else
                {
                    itemsFrame[i].GetComponentInChildren<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
                }
            }
        }
    }


    private void updateCoins(int id, int section)
    {
        //aktualizowanie ilości monet i zapisywanie od razu do pliku
        //plus zmiana tekstu ilości monet w profliu

        int beforeBuying;
        int price;
        int newScore;

        switch(section)
        {
            case 1:
                beforeBuying = int.Parse(loadCoins());
                price = int.Parse(itemsProfile[id].GetComponentInChildren<TextMeshProUGUI>().text);
                newScore = beforeBuying - price;
            break;

            case 2:
                beforeBuying = int.Parse(loadCoins());
                price = int.Parse(itemsBackground[id].GetComponentInChildren<TextMeshProUGUI>().text);
                newScore = beforeBuying - price;
            break;

            case 3:
                beforeBuying = int.Parse(loadCoins());
                price = int.Parse(itemsFrame[id].GetComponentInChildren<TextMeshProUGUI>().text);
                newScore = beforeBuying - price;
            break;

            default:
                newScore = int.Parse(loadCoins());
                Debug.Log("Problem w updateCoins");
            break;
        }

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
        else Debug.Log("Failed to update Coins" + filePath);

    }

    private void destroyItem(int id, int section)
    {
        switch(section)
        {
            case 1:
                Destroy(itemsProfile[id]);
            break;

            case 2:
                Destroy(itemsBackground[id]);
            break;

            case 3:
                Destroy(itemsFrame[id]);
            break;

            default:
                Debug.Log("Nie można było zniszczyć itemu z id: "+id+" w sekcji: "+section);
            break;
        }    
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
