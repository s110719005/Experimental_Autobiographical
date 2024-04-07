using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private int currentStage;
    public virtual void NextScene()
    {
        GameCore.Instance.ChangeStage(currentStage + 1);
    }
}
