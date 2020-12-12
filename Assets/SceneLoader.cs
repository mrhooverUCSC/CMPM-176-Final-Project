using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if(SceneManager.GetActiveScene().name != "StartMenu")
        //{
        //   SceneManager.LoadScene("StartMenu");
        //}    
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
        Canvas canvas = FindObjectOfType<Canvas>();
        Transform[] buttons = canvas.gameObject.transform.GetComponentsInChildren<Transform>();
        foreach (Transform button in buttons)
        {
            if(button.tag != "UI")
            {
                button.gameObject.SetActive(false);
            }          
        }
    }

    public void LoadThreePlayer()
    {
        SceneManager.LoadScene("Gameplay Screen 3");
    }

    public void LoadFourPlayer()
    {
        SceneManager.LoadScene("Gameplay Screen 4");
    }

    public void LoadFivePlayer()
    {
        SceneManager.LoadScene("Gameplay Screen 5");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
