using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage6Manager : StageManager
{
    private bool isClick;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private RectTransform hand;
    [SerializeField]
    private Image piano;
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

        hand.position = canvas.transform.TransformPoint(movePos);
        
        
        if(isClick && 
          (Input.GetAxis("Mouse X") > 0.1f || Input.GetAxis("Mouse X") < 0.1f || 
           Input.GetAxis("Mouse X") > 0.1f || Input.GetAxis("Mouse X") < 0.1f))
        {
            //Debug.Log("MOVING");
            CleanPiano();
        }
        if(Input.GetMouseButtonDown(0))
        {
            isClick = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isClick = false;
        }
    }

    private void CleanPiano()
    {
        piano.color = new Color(piano.color.r, piano.color.g, piano.color.b, piano.color.a - 0.0005f);
        if(piano.color.a <= 0.01f)
        {
            NextScene();
        }
    }
}
