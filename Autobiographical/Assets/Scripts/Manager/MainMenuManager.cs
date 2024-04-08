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
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip faClip;
    [SerializeField]
    private AudioClip solClip;
    [SerializeField]
    private AudioClip laClip;
    
    public void LeaveSelect()
    {
        pianoBackground.sprite = defaultPiano;
    }

    public void SelectFa()
    {
        pianoBackground.sprite = pianoFa;
        audioSource.clip = faClip;
        audioSource.Play();
    }

    public void SelectSol()
    {
        pianoBackground.sprite = pianoSol;
        audioSource.clip = solClip;
        audioSource.Play();
    }

    public void SelectLa()
    {
        pianoBackground.sprite = pianoLa;
        audioSource.clip = laClip;
        audioSource.Play();
    }
}
