using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

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
        public int current;
        public int goal;
        public bool unlocked;
    }

    [SerializeField]
    public Achievment[] achievments;

    public GameObject achievmentObj;

    private void Awake()
    {
        achievmentsManagerInstance = this;
    }

    public void addAchievmentProgress(string id, int value)
    {
        Achievment achievment = achievments.FirstOrDefault(x => x.ID == id);

        if (!achievment.unlocked)
        {
            achievment.current += value;

            if(achievment.current >= achievment.goal)
            {
                achievment.current = achievment.goal;
                achievment.unlocked = true;
                Debug.Log("Oblokowano achievment: "+achievment.title);
            }
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
            
            if(achievment.unlocked)
            {
                achButton.interactable = true;
            }
        }

        
    }
}
