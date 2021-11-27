using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System.Xml;
using System.IO;

public class AchievmentsManager : MonoBehaviour
{
    public static AchievmentsManager achievmentsManagerInstance;

    [System.Serializable]
    public class Achievment
    {
        public Sprite icon;
        public string title;
        public string description;
        public string ID;
        public string type; // !!! Profile, Background lub Frame !!!
        public int current;
        public int goal;
        public int unlocked;
        public int purchased;
    }

    [SerializeField]
    public Achievment[] achievments;

    public GameObject achievmentObj;

    private void Awake()
    {
        achievmentsManagerInstance = this;
    }

    void Start()
    {
        loadAchiementData();
    }

    public void addAchievmentProgress(string id, int value)
    {
        Achievment achievment = achievments.FirstOrDefault(x => x.ID == id);

            if (achievment.unlocked == 0)
            {
                achievment.current += value;

                if(achievment.current >= achievment.goal)
                {
                    achievment.current = achievment.goal;
                    achievment.unlocked = 1;

                    Debug.Log("Oblokowano achievment: "+achievment.title);
                }
                saveAchievmentData(int.Parse(id));
            }
    }

    public void populateAchievmentList(Transform parent)
    {
        if(parent.childCount > 0)
        {
            foreach(Transform child in parent)
            {
                Destroy(child.gameObject);
            }
        }

        foreach(Achievment achievment in achievments)
        {
            GameObject achievementObject = Instantiate(achievmentObj, parent);

            TextMeshProUGUI achTitle = achievementObject.transform.Find("AchievmentInfo").transform.Find("AchievmentTitle").GetComponent<TextMeshProUGUI>();
            achTitle.text = achievment.title;

            TextMeshProUGUI achDesc = achievementObject.transform.Find("AchievmentInfo").transform.Find("AchievmentDescription").GetComponent<TextMeshProUGUI>();
            achDesc.text = achievment.description;

            Image achImage = achievementObject.transform.Find("AchievmentImage").GetComponent<Image>();
            achImage.sprite = achievment.icon;

            Slider achProgressBar = achievementObject.transform.Find("AchievmentInfo").transform.Find("Slider").GetComponent<Slider>();
            achProgressBar.maxValue = achievment.goal;
            achProgressBar.value = achievment.current;

            Button achButton = achievementObject.transform.Find("AchievmentPurchase").GetComponent<Button>();
        
            Image achUnlocked = achievementObject.transform.Find("AchievmentPurchased").GetComponent<Image>();

            
            if(achievment.unlocked == 1)
            {
                achButton.interactable = true;
            }

            if(achievment.purchased == 1)
            {
                achButton.gameObject.SetActive(false);
                achUnlocked.gameObject.SetActive(true);
            }
        }
    }

    public void loadAchiementData()
    {
        foreach(Achievment achievment in achievments)
        {
            achievment.current = getAchievmentXml(3,int.Parse(achievment.ID));
            achievment.unlocked = (getAchievmentXml(4,int.Parse(achievment.ID)) == 1) ? 1 : 0;
            achievment.purchased = (getAchievmentXml(5,int.Parse(achievment.ID)) == 1) ? 1 : 0;
        }
    }

    public void saveAchievmentData(int achId)
    {
        Achievment achievment = achievments.FirstOrDefault(x => x.ID == achId.ToString());
        
        setAchievmentXml(3,int.Parse(achievment.ID), achievment.current);
        setAchievmentXml(4,int.Parse(achievment.ID), (achievment.unlocked == 1) ? 1 : 0);
    }

    public void setAchievmentXml(int section, int achId, int value)
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList nodelist = xmlDocument.GetElementsByTagName("Achievments");
            nodelist[0].ChildNodes[achId].ChildNodes[section].InnerText = value.ToString();

            xmlDocument.Save(filePath);

        }
        else Debug.Log("Błąd przy setAchievment");
    }

    public int getAchievmentXml(int section, int achId)
    {
        int zmienna = 0;
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList achievmentsXml = xmlDocument.GetElementsByTagName("Achievments");

            zmienna = int.Parse(achievmentsXml[0].ChildNodes[achId].ChildNodes[section].InnerText.ToString());
        }
        else Debug.Log("Achievments not get" + filePath);
         
        return zmienna;
    }

    public void writeAchievmentsToXml()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            XmlNodeList achievmentsXml = xmlDocument.GetElementsByTagName("Achievments");

            if(achievmentsXml[0].ChildNodes.Count == 0)
            {
                foreach(Achievment achievment in achievments)
                {
                    XmlElement achievmentElement = xmlDocument.CreateElement("Achievment");
                    achievmentsXml[0].AppendChild(achievmentElement);

                    XmlElement achievmentIcon = xmlDocument.CreateElement("Prize");
                    XmlElement achievmentId = xmlDocument.CreateElement("Id");
                    XmlElement achievmentType = xmlDocument.CreateElement("Type");
                    XmlElement achievmentProgress = xmlDocument.CreateElement("Current");
                    XmlElement achievmentIsUnlocked = xmlDocument.CreateElement("IsUnlocked");
                    XmlElement achievmentIsPurchased = xmlDocument.CreateElement("Purchased");

                    achievmentIcon.InnerText = achievment.icon.name;
                    achievmentId.InnerText = achievment.ID;
                    achievmentType.InnerText = achievment.type;
                    achievmentProgress.InnerText = achievment.current.ToString();
                    achievmentIsUnlocked.InnerText = achievment.unlocked.ToString();
                    achievmentIsPurchased.InnerText = achievment.purchased.ToString();

                    achievmentElement.AppendChild(achievmentIcon);
                    achievmentElement.AppendChild(achievmentId);
                    achievmentElement.AppendChild(achievmentType);
                    achievmentElement.AppendChild(achievmentProgress);
                    achievmentElement.AppendChild(achievmentIsUnlocked);
                    achievmentElement.AppendChild(achievmentIsPurchased);

                    xmlDocument.Save(filePath);
                }
            }
        }
        else Debug.Log("Błąd przy zapisywaniu achievmentów" + filePath);
    }

    
}
