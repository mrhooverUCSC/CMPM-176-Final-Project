using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBannerControl : MonoBehaviour
{
    //substitute this with the variable for the stage when it is implemented
    public Player player;
    //the player image
    public Image p1;
    public Image p2;
    public Image p3;
    public Image p4;
    public Image p5;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        //Find the game objects and get the image component
        p1 = GameObject.Find("BlueBanner").GetComponent<Image>();
        p4 = GameObject.Find("PurpleBanner").GetComponent<Image>();
        p5 = GameObject.Find("RedBanner").GetComponent<Image>();
        p2 = GameObject.Find("YellowBanner").GetComponent<Image>();
        p3 = GameObject.Find("GreenBanner").GetComponent<Image>();

        //default to the banners not being rendered
        if(p1)
        {
            p1.enabled = false;
        }
        if(p2)
        {
            p2.enabled = false;
        }
        if(p3)
        {
            p3.enabled = false;
        }
        if(p4)
        {
            p4.enabled = false;
        }
        if(p5)
        {
            p5.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = gm.GetCurrentPlayer();
        //if we are at the first player enable the image, else disable it 
        if (player.tag == "Blue" && p1)
        {
            p1.enabled = true;
        }
        else
        {
            p1.enabled = false;
        }

        //if we are at the second player enable the image, else disable it 
        if (player.tag == "Yellow" && p2)
        {
            p2.enabled = true;
        }
        else
        {
            p2.enabled = false;
        }

        //if we are at the third player enable the image, else disable it 
        if (player.tag == "Green" && p3)
        {
            p3.enabled = true;
        }
        else
        {
            p3.enabled = false;
        }

        //if we are at the fourth player enable the image, else disable it 
        if (player.tag == "Purple" && p4)
        {
            p4.enabled = true;
        }
        else
        {
            p4.enabled = false;
        }

        //if we are at the fifth player enable the image, else disable it 
        if (player.tag == "Red" && p5)
        {
            p5.enabled = true;
        }
        else
        {
            p5.enabled = false;
        }
    }
}
