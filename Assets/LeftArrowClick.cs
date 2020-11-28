using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArrowClick : MonoBehaviour
{
    public void RotateFirstTileLeft()
    {
        Tile[] Tiles = FindObjectsOfType<Tile>();
        GameObject firstTile = Tiles[0].gameObject;
        firstTile.transform.Rotate(0, 0, 60);
        //need to use rotate functions that are inside Tile
    }
}
