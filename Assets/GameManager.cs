﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class MySingleton : Singleton<MySingleton>
{
    // (Optional) Prevent non-singleton constructor use.
    protected MySingleton() { }

    // Then add whatever code to the class you need as you normally would.
    public Tile selectedTile;
}



public class GameManager : MonoBehaviour
{
    int turnIndex = 0;
    public Turn[] turns;
    public bool buttonPressed;
    public Player[] playerList;
    int playerIndex = 0;
    public Player currentPlayer;

    Tile[] tiles; // automatically make and add the tiles with appropriate tags
    [SerializeField] Tile test_tile;
    Vector3 up = new Vector3(0, -1, 0); // distance comparisons
    Vector3 up_right = new Vector3(-0.9f, -0.5f, 0.0f);
    Vector3 down_right = new Vector3(-0.9f, +0.5f, 0.0f);
    Vector3 down = new Vector3(0, 1, 0.0f);
    Vector3 down_left = new Vector3(+0.9f, +0.5f, 0.0f);
    Vector3 up_left = new Vector3(+0.9f, -0.5f, 0.0f);

    Dictionary<Tile, Tile[]> adjacency= new Dictionary<Tile, Tile[]>();
   // walls_placed[]; // holds how many walls each player has on the board for rotations/movement

    // Start is called before the first frame update
    void Start()
    {
        buttonPressed = false;
        playerList = FindObjectsOfType<Player>();
        tiles = FindObjectsOfType<Tile>();
        currentPlayer = playerList[playerIndex];
        RandomizeBoard();
        make_adjacency();
    }

    private void Update()
    {
        if (turns[turnIndex].Execute(this)) //if turn is over
        {
            turnIndex++;
            if (turnIndex > turns.Length - 1) //if the last player has taken their turn
            {
                turnIndex = 0;
                Debug.Log("Next Player");
                currentPlayer = playerList[++playerIndex % playerList.Length]; 
            }
        }
    }

    public void RandomizeBoard() 
    {
        foreach(Tile t in tiles)
        {
         t.Randomize();
        }
    }

    public void ClearSelection()
    {
        if (MySingleton.Instance.selectedTile)
        {
            MySingleton.Instance.selectedTile.ResetSelection();
        }
    }

    private void make_adjacency()
    {
        foreach(Tile t in tiles){
            Vector3 pos = t.transform.position;
            Tile[] adj = new Tile[6];
            foreach(Tile c in tiles)
            {
                Vector3 cpos = c.transform.position;
               // Debug.Log(pos + " "+ cpos);
                if(Vector3.Distance(pos, cpos + up) < .1)
                {
                    adj[0] = c;
                }
                else if (Vector3.Distance(pos, cpos + up_right) < .1)
                {
                    adj[1] = c;
                    Debug.Log(true);
                }
                else if (Vector3.Distance(pos, cpos + down_right) < .1)
                {
                    adj[2] = c;
                }
                else if (Vector3.Distance(pos, cpos + down) < .1)
                {
                    adj[3] = c;
                }
                else if (Vector3.Distance(pos, cpos + down_left) < .1)
                {
                    adj[4] = c;
                }
                else if (Vector3.Distance(pos, cpos + up_left) < .1)
                {
                    adj[5] = c;
                }
            }
            adjacency.Add(t, adj);
            //t.SetAdjcency(adj);
        }
    }

    public int GetAdjcency(Tile source, Tile target)
    {
        Vector3 spos = source.transform.position;
        Vector3 tpos = target.transform.position;
        if (Vector3.Distance(spos, tpos + up) < .1)
        {
            return 0;
        }
        else if (Vector3.Distance(spos, tpos + up_right) < .1)
        {
            return 1;
        }
        else if (Vector3.Distance(spos, tpos + down_right) < .1)
        {
            return 2;
        }
        else if (Vector3.Distance(spos, tpos + down) < .1)
        {
            return 3;
        }
        else if (Vector3.Distance(spos, tpos + down_left) < .1)
        {
            return 4;
        }
        else if (Vector3.Distance(spos, tpos + up_left) < .1)
        {
            return 5;
        }
        return -1;
    }

    public GameObject GetUI()
    {
        Canvas[] gameBoard = FindObjectsOfType<Canvas>();
        GameObject test = gameBoard[0].gameObject;
        return test.transform.GetChild(0).gameObject;
    }

    public void ToggleVisibility()
    {
        GameObject UI = GetUI();
        UI.SetActive(!UI.activeSelf);
    }

    public void Press()
    {
        buttonPressed = true;
        ClearSelection();
    }

    public void RotateFirstTileLeft()
    {
        if (MySingleton.Instance.selectedTile && MySingleton.Instance.selectedTile.IsSelect())
        {
            MySingleton.Instance.selectedTile.RotateLeft(1);
        }

    }

    public void RotateFirstTileRight()
    {
        if (MySingleton.Instance.selectedTile && MySingleton.Instance.selectedTile.IsSelect())
        {
            MySingleton.Instance.selectedTile.RotateRight(1);
        }
    }

    public void PlayerMove()
    {
        //Debug.Log(turns[turnIndex].GetCurrentPhase().phaseName);
        if (turns[turnIndex].GetCurrentPhase().phaseName == "Move")
        {
            currentPlayer.Move();
        }
    }
}
