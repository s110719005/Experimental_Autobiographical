using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage5Manager : StageManager
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private RectTransform handTransform;
    
    [SerializeField]
    private RectTransform seat;
    [SerializeField]
    private Image handle;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(seat.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition, canvas.worldCamera,
            out movePos);

        handTransform.position = canvas.transform.TransformPoint(movePos);

        if(seat.position.y >= 590)
        {
            NextScene();
        }
    }

    public void ChangeHandleColor()
    {
        handle.color  = Color.yellow;
    }
    public void ResetHandleColor()
    {
        handle.color = Color.gray;
    }

    public void IncreaseChairHeight()
    {
        seat.position = new Vector3(seat.position.x, seat.position.y + 3, 0);
        //Debug.Log(seat.position.y);
    }
}
