using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private int currentStage;
    public virtual void NextScene()
    {
        if(currentStage + 1 >= 8)
        {
            GameCore.Instance.BackToTitle();
        }
        else
        {
            GameCore.Instance.ChangeStage(currentStage + 1);
        }
    }
}
