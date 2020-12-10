using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void LoadRulesScene()
    {
        SceneManager.LoadScene("RulesScene");
    }

    public void BackToStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay Screen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
