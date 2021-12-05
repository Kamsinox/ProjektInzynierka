using UnityEngine;
using TMPro;

public class onEnteronExit : MonoBehaviour
{
    public TMP_Text textMeshPro;

    public void onExit(){
        textMeshPro.text = " ";
    }

    public void onEnter1(){
        textMeshPro.text = "Poziom łatwy";
    }

    public void onEnter2(){
        textMeshPro.text = "Poziom średni";
    }

    public void onEnter3(){
        textMeshPro.text = "Poziom trudny";
    }

    public void onEnter4(){
        textMeshPro.text = "Poziom hardcore";
    }

    public void onEnter5(){
        textMeshPro.text = "Free Play";
    }
}
