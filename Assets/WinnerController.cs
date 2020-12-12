using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerController : MonoBehaviour
{
    GameObject winner1;
    GameObject winner2;
    GameObject winner3;
    GameObject winner4;
    GameObject winner5;
    // Start is called before the first frame update
    void Start()
    {
        winner1 = GameObject.Find("BlueWin");
        winner2 = GameObject.Find("PurpleWin");
        winner3 = GameObject.Find("RedWin");
        winner4 = GameObject.Find("YellowWin");
        winner5 = GameObject.Find("GreenWin");

        winner1.SetActive(false);
        winner2.SetActive(false);
        winner3.SetActive(false);
        winner4.SetActive(false);
        winner5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(MySingleton.Instance.winner == 1)
        {
            winner1.SetActive(true);
        }
        if (MySingleton.Instance.winner == 2)
        {
            winner2.SetActive(true);
        }
        if (MySingleton.Instance.winner == 3)
        {
            winner3.SetActive(true);
        }
        if (MySingleton.Instance.winner == 4)
        {
            winner4.SetActive(true);
        }
        if (MySingleton.Instance.winner == 5)
        {
            winner5.SetActive(true);
        }
    }
}
