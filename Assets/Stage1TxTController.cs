using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1TxTController : MonoBehaviour
{
    //substitute this with the variable for the stage when it is implemented
    //public int stage = 0;
    public int stage;


    //controls when different tooltips are rendered
    public float time = 0.0f;

    //the text
    public Text txt1_1;
    public Text txt1_2;
    public Text txt2_1;
    public Text txt2_2;
    public Text txt3_1;
    public Text txt3_2;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        //Find the game objects and get the text component
        txt1_1 = GameObject.Find("S1 Text (1)").GetComponent<Text>();
        txt1_2 = GameObject.Find("S1 Text (2)").GetComponent<Text>();
        txt2_1 = GameObject.Find("S2 Text (1)").GetComponent<Text>();
        txt2_2 = GameObject.Find("S2 Text (2)").GetComponent<Text>();
        txt3_1 = GameObject.Find("S3 Text (1)").GetComponent<Text>();
        txt3_2 = GameObject.Find("S3 Text (2)").GetComponent<Text>();

        //default to text not being rendered
        txt1_1.enabled = false;
        txt1_2.enabled = false;
        txt2_1.enabled = false;
        txt2_2.enabled = false;
        txt3_1.enabled = false;
        txt3_2.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        stage = gm.GetCurrentPhase();
        //if we are at the first stage check if we should enable the text, else disable it 
        if (stage == 0)
        {
            if ((time > 0) && (time < 10))
            {
                txt1_1.enabled = true;
            }
            else
            {
                txt1_1.enabled = false;
            }

            if ((time > 10) && (time < 20))
            {
                txt1_2.enabled = true;
            }
            else
            {
                txt1_2.enabled = false;
            }
        }
        else
        {
            txt1_1.enabled = false;
            txt1_2.enabled = false;
        }

        //if we are at the second stage check if we should enable the text, else disable it 
        if (stage == 1)
        {
            if ((time > 0) && (time < 10))
            {
                txt2_1.enabled = true;
            }
            else
            {
                txt2_1.enabled = false;
            }

            if ((time > 10) && (time < 20))
            {
                txt2_2.enabled = true;
            }
            else
            {
                txt2_2.enabled = false;
            }
        }
        else
        {
            txt2_1.enabled = false;
            txt2_2.enabled = false;
        }

        //if we are at the third stage check if we should enable the text, else disable it 
        if (stage == 2)
        {
            if ((time > 0) && (time < 10))
            {
                txt3_1.enabled = true;
            }
            else
            {
                txt3_1.enabled = false;
            }

            if ((time > 10) && (time < 20))
            {
                txt3_2.enabled = true;
            }
            else
            {
                txt3_2.enabled = false;
            }
        }
        else
        {
            txt3_1.enabled = false;
            txt3_2.enabled = false;
        }

        //increment time
        time = time + (1.0f * Time.deltaTime);

        //if time is too high, reset it
        if (time > 20)
        {
            time = 0;
        }
    }
}

