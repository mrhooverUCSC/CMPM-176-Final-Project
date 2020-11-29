using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Tile[] tiles;
    Tile playerstand;
    // Start is called before the first frame update
    void Start()
    {
        tiles = FindObjectsOfType<Tile>();
    }

    public bool CheckValidMove(Tile source, Tile target)
    {
        GameManager manager = FindObjectOfType<GameManager>();
        int adjIndex = manager.GetAdjcency(source, target);
        if(adjIndex == -1)
        {
            return false;
        }
        else
        {
            bool sourceCheck = source.GetOpenings()[adjIndex];
            bool targetCheck = target.GetOpenings()[(adjIndex + 3) % 6];
            bool wallCheck = source.GetWalled()[adjIndex]; 
            if(sourceCheck && targetCheck && !wallCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public void Move()
    {
        foreach (Tile tile in tiles)
        {
            if (tile.IsSelect())
            {
                if(playerstand && CheckValidMove(playerstand, MySingleton.Instance.selectedTile) || !playerstand)
                {
                    float posx = tile.transform.position.x;
                    float posy = tile.transform.position.y;
                    transform.position = new Vector3(posx, posy, -5f);
                    playerstand = tile;
                    return;
                }
                else
                {
                    return;
                }
                
            }
        }
    }
}
