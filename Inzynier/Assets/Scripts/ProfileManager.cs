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

    public GameObject profileImage;

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
    }


    public void changeProfile(Image newImage)
    {
        Image newSprite = profileImage.GetComponent<Image>();
        newSprite.sprite = newImage.sprite;
    }
        
}
