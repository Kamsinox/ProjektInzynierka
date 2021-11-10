using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    private string text;
    public GameObject[] profileSprite;

    [Space]
    [SerializeField] TMP_Text scoreTxt;
    void Start()
    {
        loadScore();
    }

    private void loadScore()
    {
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            PlayerStats stats = new PlayerStats();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList coins = xmlDocument.GetElementsByTagName("Coins");
            text = coins[0].InnerText.ToString();
            scoreTxt.text = string.Format("Monety: {0}",(text));
        }
    }


    public void changeProfile()
    {
        Image oldProfile = GameObject.Find("ProfileImage").GetComponent<Image>();
        Image newProfile = profileSprite[1].GetComponent<Image>();

        oldProfile.sprite = newProfile.sprite;
    }
        
}
