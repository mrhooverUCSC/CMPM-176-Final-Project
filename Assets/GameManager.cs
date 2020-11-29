using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        tiles = FindObjectsOfType<Tile>();
        RandomizeBoard();
        make_adjacency();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomizeBoard() {
        foreach(Tile t in tiles)
        {
         t.Randomize();
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
        }
    }
    public void RotateFirstTileLeft()
    {
        Tile[] Tiles = FindObjectsOfType<Tile>();
        Tile firstTile = Tiles[0];
        firstTile.RotateLeft(1);
    }

    public void RotateFirstTileRight()
    {
        Tile[] Tiles = FindObjectsOfType<Tile>();
        Tile firstTile = Tiles[0];
        firstTile.RotateRight(1);
    }
}




