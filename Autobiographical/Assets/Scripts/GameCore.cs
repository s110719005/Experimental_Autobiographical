using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance;
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    public void StartNewGame()
    {
        SceneManager.LoadScene("Stage1Scene");
    }

    public void LeveSelect()
    {
        SceneManager.LoadScene("LevelSelectScene");
    }

    public void ChangeStage(int stage)
    {
        string stageName = "Stage" + stage.ToString() + "Scene";
        SceneManager.LoadScene(stageName);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
