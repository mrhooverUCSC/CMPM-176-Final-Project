using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Tile[] tiles;
    // Start is called before the first frame update
    void Start()
    {
        tiles = FindObjectsOfType<Tile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        foreach (Tile tile in tiles)
        {
            if(tile.IsSelect())
            {
                float posx = tile.transform.position.x;
                float posy = tile.transform.position.y;
                transform.position = new Vector3 (posx, posy);
            }
        }
    }
}
