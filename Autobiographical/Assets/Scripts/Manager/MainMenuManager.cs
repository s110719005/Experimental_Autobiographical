using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Image pianoBackground;
    [SerializeField]
    private Sprite defaultPiano;
    [SerializeField]
    private Sprite pianoFa;
    [SerializeField]
    private Sprite pianoSol;
    [SerializeField]
    private Sprite pianoLa;
    
    public void LeaveSelect()
    {
        pianoBackground.sprite = defaultPiano;
    }

    public void SelectFa()
    {
        pianoBackground.sprite = pianoFa;
    }

    public void SelectSol()
    {
        pianoBackground.sprite = pianoSol;
    }

    public void SelectLa()
    {
        pianoBackground.sprite = pianoLa;
    }
}
