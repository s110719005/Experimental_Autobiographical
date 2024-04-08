using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2Manager : StageManager
{
    // Start is called before the first frame update
    private bool isOpen = false;
    [SerializeField]
    private Canvas xylophoneCanvas;
    [SerializeField]
    private Image xylophoneBox;
    [SerializeField]
    private Image xylophone;
    [SerializeField]
    private Sprite xylophoneBoxOpen;
    [SerializeField]
    private Sprite xylophoneDefault;
    [SerializeField]
    private Sprite[] xylophoneNotesSelect;
    [SerializeField]
    private RectTransform stickTransform;
    [SerializeField]
    private GameObject buttons;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] noteSounds;

    private int currentClickCount = 0;
    void Start()
    {
         xylophone.gameObject.SetActive(false);
         buttons.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isOpen)
        {
            OpenBox();
        }

        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            xylophoneCanvas.transform as RectTransform,
            Input.mousePosition, xylophoneCanvas.worldCamera,
            out movePos);

        stickTransform.position = xylophoneCanvas.transform.TransformPoint(movePos);

        if (currentClickCount >= 20)
        {
            NextScene();
        }
    }

    private void OpenBox()
    {
        xylophoneBox.sprite = xylophoneBoxOpen;
         xylophone.gameObject.SetActive(true);
         buttons.gameObject.SetActive(true);
    }

    public void ChangeSelection(int selection)
    {
        xylophone.sprite = xylophoneNotesSelect[selection];
    }

    public void ResetSelection()
    {
        xylophone.sprite = xylophoneDefault;
    }

    public void PlaySound(int index)
    {
        audioSource.Stop();
        audioSource.clip = noteSounds[index];
        audioSource.Play();
        currentClickCount++;
    }
}
