using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickScript : MonoBehaviour
{

    //THIS NEEDS TO BE UPDATED TO BE THE TILE THEY CLICK ON
    public GameObject GetUI()
    {
        Canvas[] gameBoard = FindObjectsOfType<Canvas>();
        GameObject test = gameBoard[0].gameObject;
        return test.transform.GetChild(0).gameObject;
    }

    //GameObject UI2 = clickScript1.GetUI();
    //UI2.transform.Rotate(0, 0, -60);

    public void ToggleVisibility()
    {
        GameObject UI = GetUI();
        UI.SetActive(!UI.activeSelf);
    }
}
