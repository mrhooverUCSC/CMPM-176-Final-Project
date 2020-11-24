using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //if tile is clicked on
            //ToggleVisibility()
    }

    public void ToggleVisibility()
    {
        //var render = GameObject.GetComponentsInChildren<GameObject>();
        //foreach (GameObject obj in render)
        //{
        //    if (obj.tag == "UI")
        //    {
        //        obj.activeSelf = !obj.activeSelf;
        //    }
        //}
        var rotation = GameObject.Find("RotationUI");
        rotation.SetActive(!rotation.activeSelf);
    }
}
