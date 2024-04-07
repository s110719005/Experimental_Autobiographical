using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Manager : StageManager
{
    [SerializeField]
    private GameObject notes;
    public void ShowNotes(bool showNotes)
    {
        notes.SetActive(showNotes);
    }
}
