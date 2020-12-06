using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBannerControl : MonoBehaviour
{
    //substitute this with the variable for the stage when it is implemented
    public float player = 1.0f;
    //the player image
    public Image p1;
    public Image p2;
    public Image p3;
    public Image p4;
    public Image p5;

    // Start is called before the first frame update
    void Start()
    {
        //Find the game objects and get the image component
        p1 = GameObject.Find("RedBanner").GetComponent<Image>();
        p2 = GameObject.Find("PurpleBanner").GetComponent<Image>();
        p3 = GameObject.Find("YellowBanner").GetComponent<Image>();
        p4 = GameObject.Find("GreenBanner").GetComponent<Image>();
        p5 = GameObject.Find("BlueBanner").GetComponent<Image>();

        //default to the banners not being rendered
        p1.enabled = false;
        p2.enabled = false;
        p3.enabled = false;
        p4.enabled = false;
        p5.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if we are at the first player enable the image, else disable it 
        if (player == 1.0f)
        {
            p1.enabled = true;
        }
        else
        {
            p1.enabled = false;
        }

        //if we are at the second player enable the image, else disable it 
        if (player == 2.0f)
        {
            p2.enabled = true;
        }
        else
        {
            p2.enabled = false;
        }

        //if we are at the third player enable the image, else disable it 
        if (player == 3.0f)
        {
            p3.enabled = true;
        }
        else
        {
            p3.enabled = false;
        }

        //if we are at the fourth player enable the image, else disable it 
        if (player == 4.0f)
        {
            p4.enabled = true;
        }
        else
        {
            p4.enabled = false;
        }

        //if we are at the fifth player enable the image, else disable it 
        if (player == 5.0f)
        {
            p5.enabled = true;
        }
        else
        {
            p5.enabled = false;
        }
    }
}
