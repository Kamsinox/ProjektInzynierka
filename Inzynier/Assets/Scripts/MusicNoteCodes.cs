using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNoteCodes : MonoBehaviour
{
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


    void Update()
    {
        #region granieNaKlawiaturze
        //tak wiem if-y na potęge, ale inaczej się nie da
        //boli to nawet mnie - Kx
        if(Input.GetKey(KeyCode.A))             C_Note_Play();
        else if (Input.GetKey(KeyCode.W))       CS_Note_Play();
        else if (Input.GetKey(KeyCode.S))       D_Note_Play();
        else if (Input.GetKey(KeyCode.E))       DS_Note_Play();
        else if (Input.GetKey(KeyCode.D))       E_Note_Play();
        else if (Input.GetKey(KeyCode.F))       F_Note_Play();
        else if (Input.GetKey(KeyCode.T))       FS_Note_Play();
        else if (Input.GetKey(KeyCode.G))       G_Note_Play();
        else if (Input.GetKey(KeyCode.Y))       GS_Note_Play();
        else if (Input.GetKey(KeyCode.H))       A_Note_Play();
        else if (Input.GetKey(KeyCode.U))       Bb_Note_Play();
        else if (Input.GetKey(KeyCode.J))       B_Note_Play();
        else if (Input.GetKey(KeyCode.K))       C1_Note_Play();
        else if (Input.GetKey(KeyCode.O))       CS1_Note_Play();
        else if (Input.GetKey(KeyCode.L))       D1_Note_Play(); 
        else if (Input.GetKey(KeyCode.P))       DS1_Note_Play();
        else if (Input.GetKey(KeyCode.Semicolon))E1_Note_Play();
        #endregion

    }


    public void C_Note_Play()
    {
        C_Note.Play();
    }

    public void D_Note_Play()
    {
        D_Note.Play();
    }

    public void E_Note_Play()
    {
        E_Note.Play();
    }

    public void F_Note_Play()
    {
        F_Note.Play();
    }

    public void G_Note_Play()
    {
        G_Note.Play();
    }

    public void A_Note_Play()
    {
        A_Note.Play();
    }

    public void B_Note_Play()
    {
        B_Note.Play();
    }

    public void C1_Note_Play()
    {
        C1_Note.Play();
    }

    public void D1_Note_Play()
    {
        D1_Note.Play();
    }

    public void E1_Note_Play()
    {
        E1_Note.Play();
    }

    public void CS_Note_Play()
    {
        CS_Note.Play();
    }

    public void DS_Note_Play()
    {
        DS_Note.Play();
    }

    public void FS_Note_Play()
    {
        FS_Note.Play();
    }

    public void GS_Note_Play()
    {
        GS_Note.Play();
    }

    public void Bb_Note_Play()
    {
        Bb_Note.Play();
    }

    public void CS1_Note_Play()
    {
        CS1_Note.Play();
    }

    public void DS1_Note_Play()
    {
        DS1_Note.Play();
    }



}
