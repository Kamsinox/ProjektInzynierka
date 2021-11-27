using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class MusicNoteCodes : MonoBehaviour
{
    #region AudioSources
    public AudioSource C_Note;
    public AudioSource D_Note;
    public AudioSource E_Note;
    public AudioSource F_Note;
    public AudioSource G_Note;
    public AudioSource A_Note;
    public AudioSource B_Note;
    public AudioSource C1_Note;
    public AudioSource D1_Note;
    public AudioSource E1_Note;
    public AudioSource CS_Note;
    public AudioSource DS_Note;
    public AudioSource FS_Note;
    public AudioSource GS_Note;
    public AudioSource Bb_Note;
    public AudioSource CS1_Note;
    public AudioSource DS1_Note;
    #endregion

    private int notesPlayed;

    public Button buttontest;

    void Update()
    {
        #region granieNaKlawiaturze
        //tak wiem if-y na potęge, ale inaczej się nie da
        if (Input.GetKeyDown(KeyCode.A))       C_Note_Play();
        if (Input.GetKeyDown(KeyCode.W))       CS_Note_Play();
        if (Input.GetKeyDown(KeyCode.S))       D_Note_Play();
        if (Input.GetKeyDown(KeyCode.E))       DS_Note_Play();
        if (Input.GetKeyDown(KeyCode.D))       E_Note_Play();
        if (Input.GetKeyDown(KeyCode.F))       F_Note_Play();
        if (Input.GetKeyDown(KeyCode.T))       FS_Note_Play();
        if (Input.GetKeyDown(KeyCode.G))       G_Note_Play();
        if (Input.GetKeyDown(KeyCode.Y))       GS_Note_Play();
        if (Input.GetKeyDown(KeyCode.H))       A_Note_Play();
        if (Input.GetKeyDown(KeyCode.U))       Bb_Note_Play();
        if (Input.GetKeyDown(KeyCode.J))       B_Note_Play();
        if (Input.GetKeyDown(KeyCode.K))       C1_Note_Play();
        if (Input.GetKeyDown(KeyCode.O))       CS1_Note_Play();
        if (Input.GetKeyDown(KeyCode.L))       D1_Note_Play(); 
        if (Input.GetKeyDown(KeyCode.P))       DS1_Note_Play();
        if (Input.GetKeyDown(KeyCode.Semicolon))E1_Note_Play();
        #endregion

    }

    #region playNote
    public void C_Note_Play()
    {
        C_Note.Play();
        countNotesPlayed();
    }

    public void D_Note_Play()
    {
        D_Note.Play();
        countNotesPlayed();
    }

    public void E_Note_Play()
    {
        E_Note.Play();
        countNotesPlayed();
    }

    public void F_Note_Play()
    {
        F_Note.Play();
        countNotesPlayed();
    }

    public void G_Note_Play()
    {
        G_Note.Play();
        countNotesPlayed();
    }

    public void A_Note_Play()
    {
        A_Note.Play();
        countNotesPlayed();
    }

    public void B_Note_Play()
    {
        B_Note.Play();
        countNotesPlayed();
    }

    public void C1_Note_Play()
    {
        C1_Note.Play();
        countNotesPlayed();
    }

    public void D1_Note_Play()
    {
        D1_Note.Play();
        countNotesPlayed();
    }

    public void E1_Note_Play()
    {
        E1_Note.Play();
        countNotesPlayed();
    }

    public void CS_Note_Play()
    {
        CS_Note.Play();
        countNotesPlayed();
    }

    public void DS_Note_Play()
    {
        DS_Note.Play();
        countNotesPlayed();
    }

    public void FS_Note_Play()
    {
        FS_Note.Play();
        countNotesPlayed();
    }

    public void GS_Note_Play()
    {
        GS_Note.Play();
        countNotesPlayed();
    }

    public void Bb_Note_Play()
    {
        Bb_Note.Play();
        countNotesPlayed();
    }

    public void CS1_Note_Play()
    {
        CS1_Note.Play();
        countNotesPlayed();
    }

    public void DS1_Note_Play()
    {
        DS1_Note.Play();
        countNotesPlayed();
    }
    #endregion


    private void countNotesPlayed()
    {
        int notesForAchivement = 0;
        string filePath = Application.dataPath + "/Data.txt";
        if(File.Exists(filePath))
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList notesPlayedElement = xmlDocument.GetElementsByTagName("FreePlayNotesPlayed");
            notesPlayed = int.Parse(notesPlayedElement[0].InnerText.ToString());
            notesPlayed++;
            notesForAchivement++;
            notesPlayedElement[0].InnerText = notesPlayed.ToString();

            xmlDocument.Save(filePath);

        }
        else Debug.Log("FILE NOT LOADED for counting notes played in free play + filePath");

        AchievmentsManager.achievmentsManagerInstance.addAchievmentProgress("6",notesForAchivement);
        AchievmentsManager.achievmentsManagerInstance.addAchievmentProgress("7",notesForAchivement);
    }

}
