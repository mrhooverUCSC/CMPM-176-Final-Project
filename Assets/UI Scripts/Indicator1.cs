using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator1 : MonoBehaviour
{
    //substitute this with the variable for the stage when it is implemented
    public float stage = 1.0f;
    //the stage 1 indicator image
    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = this.gameObject.GetComponent<Image>();
        //default to the image not being rendered
        img.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if we are at the first stage enable the image, else disable it 
        if (stage == 1.0f)
        {
            img.enabled = true;
        }
        else
        {
            img.enabled = false;
        }
    }
}
