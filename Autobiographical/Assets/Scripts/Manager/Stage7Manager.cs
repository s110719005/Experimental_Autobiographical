using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage7Manager : StageManager
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private RectTransform hand;

    private bool isBusy = false;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] sonatinaClips;

    private int currentClip = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition, canvas.worldCamera,
            out movePos);

        hand.position = new Vector3(canvas.transform.TransformPoint(movePos).x, hand.position.y, 0);

        if(Input.GetMouseButtonDown(0) && !isBusy)
        {
            PlayMusic();
        }
        
    }

    private void PlayMusic()
    {
        StartCoroutine(PlayMusicEnumerator());
    }

    private IEnumerator PlayMusicEnumerator()
    {
        if(currentClip >= sonatinaClips.Length)
        {
            NextScene();
            yield break;
        }
        isBusy = true;
        audioSource.clip = sonatinaClips[currentClip];
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        isBusy = false;
        currentClip++;
        yield return null;
    }
}
