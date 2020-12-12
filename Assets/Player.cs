using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Tile[] tiles;
    [SerializeField] Walls[] walls;
    public int wallindex;
    Tile playerstand;
    [SerializeField] public string playername;
    // Start is called before the first frame update
    void Start()
    {
        tiles = FindObjectsOfType<Tile>();
    }

    public bool CheckValidMove(Tile source, Tile target)
    {
        GameManager manager = FindObjectOfType<GameManager>();
        int adjIndex = manager.GetAdjcency(source, target);
        if (adjIndex == -1)
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
                foreach (Player player in FindObjectOfType<GameManager>().playerList) //two player can't stand at same tile
                {
                    if (player.playerstand)
                    {
                        if (tile == player.playerstand)
                        {
                            return;
                        }
                    }

                }
                if (playerstand && CheckValidMove(playerstand, MySingleton.Instance.selectedTile) || !playerstand)
                {
                    if(!playerstand)
                    {
                        if(MySingleton.Instance.selectedTile.tag != "Start")
                        {
                            return;
                        } 
                    }
                    float posx = tile.transform.position.x;
                    float posy = tile.transform.position.y;
                    transform.position = new Vector3(posx, posy, -5f);
                    playerstand = tile;
                    FindObjectOfType<GameManager>().moveTimes -= 1;
                    if(tile.gameObject.tag == "End") {
                        FindObjectOfType<GameManager>().end_game();
                        if(this.tag == "Blue")
                        {
                            MySingleton.Instance.winner = 1;
                        }
                        else if (this.tag == "Purple")
                        {
                            MySingleton.Instance.winner = 2;
                        }
                        else if (this.tag == "Red")
                        {
                            MySingleton.Instance.winner = 3;
                        }
                        else if (this.tag == "Yellow")
                        {
                            MySingleton.Instance.winner = 4;
                        }
                        else if (this.tag == "Green")
                        {
                            MySingleton.Instance.winner = 5;
                        }
                        SceneManager.LoadScene("End Screen");
                    }
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
               // Debug.Log("FOUND A WALL THAT IS PLACED");
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
            if(player.tag != playername)
            {
                count += player.GetMoveTimes();
            }
        }
        count = Mathf.CeilToInt((float) count / 2);
        if(count > 5)
        {
            count = 5;
        }
        //Debug.Log(count);
        return count;
    }

    public Walls[] GetWalls()
    {
        return this.walls;
    }

    public bool checkWallOwner(Walls wall)
    {
        foreach(Walls w in walls)
        {
            if(MySingleton.Instance.selectedWall == w)
            {
                return true;
            }
        }
        return false;
    }
}
