using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorControl : MonoBehaviour
{
    //substitute this with the variable for the stage when it is implemented
    public int stage;
    //the stage indicator image
    public Image img1;
    public Image img2;
    public Image img3;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        //Find the game objects and get the image component
        img1 = GameObject.Find("Stage 1 Indicator").GetComponent<Image>();
        img2 = GameObject.Find("Stage 2 Indicator").GetComponent<Image>();
        img3 = GameObject.Find("Stage 3 Indicator").GetComponent<Image>();

        //default to stage 1 being rendered
        img1.enabled = true;

        //default to the other 2 stages not being rendered
        img2.enabled = false;
        img3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        stage = gm.GetCurrentPhase();
        //if we are at the first stage enable the image, else disable it 
        if (stage == 0)
        {
            img1.enabled = true;
        }
        else
        {
            img1.enabled = false;
        }

        //if we are at the second stage enable the image, else disable it 
        if (stage == 1)
        {
            img2.enabled = true;
        }
        else
        {
            img2.enabled = false;
        }

        //if we are at the third stage enable the image, else disable it 
        if (stage == 2)
        {
            img3.enabled = true;
        }
        else
        {
            img3.enabled = false;
        }
    }
}
