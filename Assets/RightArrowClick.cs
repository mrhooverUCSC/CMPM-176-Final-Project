using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArrowClick : MonoBehaviour
{
    public void RotateFirstTileRight()
    {
        Tile[] Tiles = FindObjectsOfType<Tile>();
        GameObject firstTile = Tiles[0].gameObject;
        firstTile.transform.Rotate(0, 0, -60);
    }
}
