using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Tile[] tiles;
    [SerializeField] Walls[] walls;
    public int wallindex;
    Tile playerstand;
    [SerializeField] string name;
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
            bool adjWall = target.GetWalled()[(adjIndex + 3) % 6];
            if(sourceCheck && targetCheck && !wallCheck && !adjWall)
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
                    FindObjectOfType<GameManager>().moveTimes -= 1;
                    return;
                }
                else
                {
                    return;
                }
                
            }
        }
    }

    public int GetMoveTimes()
    {
        int count = 0;
        foreach(Walls wall in walls)
        {
            if(wall.isPlaced)
            {
                count++;
            }
        }
        return count;
    }

    public int GetRotateTimes()
    {
        int count = 0;
        Player[] players = FindObjectsOfType<Player>();
        foreach(Player player in players)
        {
            if(player.tag != name)
            {
                count += player.GetMoveTimes();
            }
        }
        count = Mathf.CeilToInt((float) count / 2);
        if(count > 5)
        {
            count = 5;
        }
        Debug.Log(count);
        return count;
    }
}
