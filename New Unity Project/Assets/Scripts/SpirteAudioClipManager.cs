using UnityEngine;
using UnityEngine.UI;

public class SpirteAudioClipManager : MonoBehaviour
{
    // WAŻNE JEST ABY KOLEJNOŚĆ SPRITEÓW MIAŁA TAKIE SAME DŹWIĘKI JAK KOLEJNOŚĆ AUDIOCLIPÓW
    // czyli jeżeli pod id=3 jest sprite e3e3, to dla audioclipów dla id=3 musi być dźwięk e3e3

    // NAZWA OBIEKTU IMAGE ZAWSZE MUSI BYĆ: "QuestionImage"
    // NAZWA PRZYCISKU DO ODTWORZENIA DŹWIĘKU MUSI BYĆ ZGODNA Z KODEM ORAZ DŹWIĘKIEM JAKI CHCEMY ZAGRAĆ
    
     public Sprite[] spritesPryma;
     public AudioClip[] audioClipsPryma;

     [Space]

     public Sprite[] spritesSekundaMala;
     public AudioClip[] audioClipsSekundaMala;

     [Space]

     public Sprite[] spritesSekundaWielka;
     public AudioClip[] audioClipsSekundaWielka;

     [Space]

    public Sprite[] spritesTercjaMala;
    public AudioClip[] audioClipsTercjaMala;

     [Space]

    public Sprite[] spritesTercjaWielka;
    public AudioClip[] audioClipsTercjaWielka;

    [Space]

    public Sprite[] spritesKwarta;
    public AudioClip[] audioClipsKwarta;

    [Space]

    public Sprite[] spritesKwinta;
    public AudioClip[] audioClipsKwinta;

    [Space]

    public Sprite[] spritesSekstaMala;
    public AudioClip[] audioClipsSekstaMala;

    [Space]

    public Sprite[] spritesSekstaWielka;
    public AudioClip[] audioClipsSekstaWielka;

    [Space]

    public Sprite[] spritesSeptymaMala;
    public AudioClip[] audioClipsSeptymaMala;

    [Space]

    public Sprite[] spritesSeptymaWielka;
    public AudioClip[] audioClipsSeptymaWielka;

    [Space]

    public Sprite[] spritesOktawa;
    public AudioClip[] audioClipsOktawa;


    private int arraySize;
    private int randomNumber;


    public void randomLevelPryma()
    {
        arraySize = spritesPryma.Length;
        randomNumber = Random.Range(0,arraySize);

        Image image = GameObject.Find("QuestionImage").GetComponent<Image>();
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesPryma").GetComponent<AudioSource>();

        if(image is null || audioButton is null) Debug.Log("Object o nazwie Immage lub AudioSource nie został znaleziony");
        else 
        {
            //Debug.Log("Wylosowany nr: "+randomNumber);
            image.sprite = spritesPryma[randomNumber];
            audioButton.clip = audioClipsPryma[randomNumber];
            audioButton.Play();
        }
    }
    public void playPryma()
    {
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesPryma").GetComponent<AudioSource>();
        audioButton.Play();
    }


    public void randomLevelSekundaMala()
    {
        arraySize = spritesSekundaMala.Length;
        randomNumber = Random.Range(0,arraySize);

        Image image = GameObject.Find("QuestionImage").GetComponent<Image>();
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesSekMal").GetComponent<AudioSource>();

        if(image is null || audioButton is null) Debug.Log("Object o nazwie Immage lub AudioSource nie został znaleziony");
        else 
        {
            //Debug.Log("Wylosowany nr: "+randomNumber);
            image.sprite = spritesSekundaMala[randomNumber];
            audioButton.clip = audioClipsSekundaMala[randomNumber];
            audioButton.Play();
        }
    }
    public void playSekundaMala()
    {
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesSekMal").GetComponent<AudioSource>();
        audioButton.Play();
    }


    public void randomLevelSekundaWielka()
    {
        arraySize = spritesSekundaWielka.Length;
        randomNumber = Random.Range(0,arraySize);

        Image image = GameObject.Find("QuestionImage").GetComponent<Image>();
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesSekWiel").GetComponent<AudioSource>();

        if(image is null || audioButton is null) Debug.Log("Object o nazwie Immage lub AudioSource nie został znaleziony");
        else 
        {
            //Debug.Log("Wylosowany nr: "+randomNumber);
            image.sprite = spritesSekundaWielka[randomNumber];
            audioButton.clip = audioClipsSekundaWielka[randomNumber];
            audioButton.Play();
        }
    }
    public void playSekundaWielka()
    {
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesSekWiel").GetComponent<AudioSource>();
        audioButton.Play();
    }


    public void randomLevelTercjaMala()
    {
        arraySize = spritesTercjaMala.Length;
        randomNumber = Random.Range(0,arraySize);

        Image image = GameObject.Find("QuestionImage").GetComponent<Image>();
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesTerMal").GetComponent<AudioSource>();

        if(image is null || audioButton is null) Debug.Log("Object o nazwie Immage lub AudioSource nie został znaleziony");
        else 
        {
            //Debug.Log("Wylosowany nr: "+randomNumber);
            image.sprite = spritesTercjaMala[randomNumber];
            audioButton.clip = audioClipsTercjaMala[randomNumber];
            audioButton.Play();
        }
    }
    public void playTercjaMala()
    {
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesTerMal").GetComponent<AudioSource>();
        audioButton.Play();
    }


    public void randomLevelTercjaWielka()
    {
        arraySize = spritesTercjaWielka.Length;
        randomNumber = Random.Range(0,arraySize);

        Image image = GameObject.Find("QuestionImage").GetComponent<Image>();
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesTerWiel").GetComponent<AudioSource>();

        if(image is null || audioButton is null) Debug.Log("Object o nazwie Immage lub AudioSource nie został znaleziony");
        else 
        {
            //Debug.Log("Wylosowany nr: "+randomNumber);
            image.sprite = spritesTercjaWielka[randomNumber];
            audioButton.clip = audioClipsTercjaWielka[randomNumber];
            audioButton.Play();
        }
    }
    public void playTercjaWielka()
    {
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesTerWiel").GetComponent<AudioSource>();
        audioButton.Play();
    }
    

    public void randomLevelKwarta()
    {
        arraySize = spritesKwarta.Length;
        randomNumber = Random.Range(0,arraySize);

        Image image = GameObject.Find("QuestionImage").GetComponent<Image>();
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesKwarta").GetComponent<AudioSource>();

        if(image is null || audioButton is null) Debug.Log("Object o nazwie Immage lub AudioSource nie został znaleziony");
        else 
        {
            //Debug.Log("Wylosowany nr: "+randomNumber);
            image.sprite = spritesKwarta[randomNumber];
            audioButton.clip = audioClipsKwarta[randomNumber];
            audioButton.Play();
        }
    }
    public void playKwarta()
    {
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesKwarta").GetComponent<AudioSource>();
        audioButton.Play();
    }


    public void randomLevelKwinta()
    {
        arraySize = spritesKwinta.Length;
        randomNumber = Random.Range(0,arraySize);

        Image image = GameObject.Find("QuestionImage").GetComponent<Image>();
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesKwinta").GetComponent<AudioSource>();

        if(image is null || audioButton is null) Debug.Log("Object o nazwie Immage lub AudioSource nie został znaleziony");
        else 
        {
            //Debug.Log("Wylosowany nr: "+randomNumber);
            image.sprite = spritesKwinta[randomNumber];
            audioButton.clip = audioClipsKwinta[randomNumber];
            audioButton.Play();
        }
    }
    public void playKwinta()
    {
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesKwinta").GetComponent<AudioSource>();
        audioButton.Play();
    }


    public void randomLevelSekstaMala()
    {
        arraySize = spritesSekstaMala.Length;
        randomNumber = Random.Range(0,arraySize);

        Image image = GameObject.Find("QuestionImage").GetComponent<Image>();
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesSekstaMala").GetComponent<AudioSource>();

        if(image is null || audioButton is null) Debug.Log("Object o nazwie Immage lub AudioSource nie został znaleziony");
        else 
        {
            //Debug.Log("Wylosowany nr: "+randomNumber);
            image.sprite = spritesSekstaMala[randomNumber];
            audioButton.clip = audioClipsSekstaMala[randomNumber];
            audioButton.Play();
        }
    }
    public void playSekstaMala()
    {
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesSekstaMala").GetComponent<AudioSource>();
        audioButton.Play();
    }


    public void randomLevelSekstaWielka()
    {
        arraySize = spritesSekstaWielka.Length;
        randomNumber = Random.Range(0,arraySize);

        Image image = GameObject.Find("QuestionImage").GetComponent<Image>();
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesSekstaWielka").GetComponent<AudioSource>();

        if(image is null || audioButton is null) Debug.Log("Object o nazwie Immage lub AudioSource nie został znaleziony");
        else 
        {
            //Debug.Log("Wylosowany nr: "+randomNumber);
            image.sprite = spritesSekstaWielka[randomNumber];
            audioButton.clip = audioClipsSekstaWielka[randomNumber];
            audioButton.Play();
        }
    }
    public void playSekstaWielka()
    {
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesSekstaWielka").GetComponent<AudioSource>();
        audioButton.Play();
    }


    public void randomLevelSeptymaMala()
    {
        arraySize = spritesSeptymaMala.Length;
        randomNumber = Random.Range(0,arraySize);

        Image image = GameObject.Find("QuestionImage").GetComponent<Image>();
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesSeptymaMala").GetComponent<AudioSource>();

        if(image is null || audioButton is null) Debug.Log("Object o nazwie Immage lub AudioSource nie został znaleziony");
        else 
        {
            //Debug.Log("Wylosowany nr: "+randomNumber);
            image.sprite = spritesSeptymaMala[randomNumber];
            audioButton.clip = audioClipsSeptymaMala[randomNumber];
            audioButton.Play();
        }
    }
    public void playSeptymaMala()
    {
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesSeptymaMala").GetComponent<AudioSource>();
        audioButton.Play();
    }


    public void randomLevelSeptymaWielka()
    {
        arraySize = spritesSeptymaWielka.Length;
        randomNumber = Random.Range(0,arraySize);

        Image image = GameObject.Find("QuestionImage").GetComponent<Image>();
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesSeptymaWielka").GetComponent<AudioSource>();

        if(image is null || audioButton is null) Debug.Log("Object o nazwie Immage lub AudioSource nie został znaleziony");
        else 
        {
            //Debug.Log("Wylosowany nr: "+randomNumber);
            image.sprite = spritesSeptymaWielka[randomNumber];
            audioButton.clip = audioClipsSeptymaWielka[randomNumber];
            audioButton.Play();
        }
    }
    public void playSeptymaWielka()
    {
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesSeptymaWielka").GetComponent<AudioSource>();
        audioButton.Play();
    }


    public void randomLevelOktawa()
    {
        arraySize = spritesOktawa.Length;
        randomNumber = Random.Range(0,arraySize);

        Image image = GameObject.Find("QuestionImage").GetComponent<Image>();
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesOktawa").GetComponent<AudioSource>();

        if(image is null || audioButton is null) Debug.Log("Object o nazwie Immage lub AudioSource nie został znaleziony");
        else 
        {
            //Debug.Log("Wylosowany nr: "+randomNumber);
            image.sprite = spritesOktawa[randomNumber];
            audioButton.clip = audioClipsOktawa[randomNumber];
            audioButton.Play();
        }
    }
    public void playOktawa()
    {
        AudioSource audioButton = GameObject.Find("ButtonPlayTwoNotesOktawa").GetComponent<AudioSource>();
        audioButton.Play();
    }

    
    //w przyszłości może będzie tryton (jak już się ogarnie spirtey i audioclipy)
}
