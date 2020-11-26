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
        Tile[] Tiles = FindObjectsOfType<Tile>();
        GameObject test = Tiles[0].gameObject;
        GameObject UI = test.transform.GetChild(0).gameObject;
        UI.SetActive(!UI.activeSelf);
    }
}
