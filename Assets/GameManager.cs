using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.UI;
using UnityEngine;

public class MySingleton : Singleton<MySingleton>
{
    // (Optional) Prevent non-singleton constructor use.
    protected MySingleton() { }

    // Then add whatever code to the class you need as you normally would.
    public Tile selectedTile;
    public Walls selectedWall;
    public int winner;
}



public class GameManager : MonoBehaviour
{
    int turnIndex = 0;
    public Turn[] turns;
    public bool buttonPressed;
    public Player[] playerList;
    int playerIndex = 0;
    public Player currentPlayer;
    public int moveTimes;
    public int rotateTimes;
    int wallIndex;
    private bool game_over;

    Tile[] tiles; // automatically make and add the tiles with appropriate tags
    [SerializeField] Walls tester; // remove the tester object for the wall objects
    [SerializeField] Camera main_camera;
    [SerializeField] Text remainText;
    Vector3 up = new Vector3(0, -1, 0); // distance comparisons
    Vector3 up_right = new Vector3(-0.9f, -0.5f, 0.0f);
    Vector3 down_right = new Vector3(-0.9f, +0.5f, 0.0f);
    Vector3 down = new Vector3(0, 1, 0.0f);
    Vector3 down_left = new Vector3(+0.9f, +0.5f, 0.0f);
    Vector3 up_left = new Vector3(+0.9f, -0.5f, 0.0f);

    Vector3[] edge_distances;
    public bool holding_tile = false;
    public bool placeMode = false;
    public bool removeMode = false;

    Dictionary<Tile, Tile[]> adjacency = new Dictionary<Tile, Tile[]>();
  // walls_placed[]; // holds how many walls each player has on the board for rotations/movement

  // Start is called before the first frame update
  void Start() {
    buttonPressed = false;
    game_over = false;
    playerList = FindObjectsOfType<Player>();
    tiles = FindObjectsOfType<Tile>();
    currentPlayer = playerList[playerIndex];
    edge_distances = new Vector3[6] { up, up_right, down_right, down, down_left, up_left };
    //RandomizeBoard();
    make_adjacency();
  }

    private void Update()
    {
        if(game_over) {
            
        }
        if(GetCurrentPhaseName() == "Wall")
        {
            remainText.text = 1.ToString();
        }
        if(GetCurrentPhaseName() == "Move")
        {
            Debug.Log(currentPlayer.playername);
            /*
            Walls[] firstWall = currentPlayer.GetWalls();
            foreach (Walls y in firstWall)
            {
                //Debug.Log(y.isPlaced);
            }
            */
            if(currentPlayer.GetMoveTimes() == 0)
            {
                Press();
            }
            remainText.text = moveTimes.ToString();
        }
        if (GetCurrentPhaseName() == "Rotate")
        {
            if(currentPlayer.GetRotateTimes() == 0)
            {
                Press();
            }
            remainText.text = rotateTimes.ToString();
        }
        if (GetCurrentPhaseName() == "Wall")
        {
            foreach (Tile tile in tiles)
            {
                tile.GetComponent<PolygonCollider2D>().enabled = false;
            }
        }
        else
        {
            foreach (Tile tile in tiles)
            {
                tile.GetComponent<PolygonCollider2D>().enabled = true;
            }
        }

        if (holding_tile && placeMode)
        {
            Vector3 mouse_position = main_camera.ScreenToWorldPoint(Input.mousePosition);

            Tile closest = tiles[0];
            double distance = Vector3.Distance(closest.transform.position, mouse_position);
            foreach (Tile t in tiles)
            {
                if (distance > Vector3.Distance(t.transform.position, mouse_position) && t.tag != "Start")
                {
                    closest = t;
                    distance = Vector3.Distance(t.transform.position, mouse_position);
                }
            }
            // tester.transform.position = closest.transform.position;

            Vector3 closest_edge = edge_distances[0] / 2;
            double edge_distance = Mathf.Infinity;
            int dir = 0;
            for (int i = 0; i < edge_distances.Length; i++)
            {
                if (edge_distance > Vector3.Distance(mouse_position, closest.transform.position - edge_distances[i] / 2) && adjacency[closest][i] && !closest.GetWalled()[i] && !adjacency[closest][i].GetWalled()[(i + 3)%6] && adjacency[closest][i].tag != "Start")
                {
                    closest_edge = edge_distances[i] / 2;
                    edge_distance = Vector3.Distance(mouse_position, closest.transform.position - edge_distances[i] / 2);
                    wallIndex = i;

                }
            }
            if (MySingleton.Instance.selectedWall && MySingleton.Instance.selectedWall.IsSelected() && closest.tag != "Start")
            {
                if(wallIndex == 1 || wallIndex == 4) {
                  MySingleton.Instance.selectedWall.gameObject.transform.rotation = Quaternion.Euler(0, 0, 120);
                }
                else if(wallIndex == 2 || wallIndex == 5) {
                  MySingleton.Instance.selectedWall.gameObject.transform.rotation = Quaternion.Euler(0, 0, 240);
                }
                else {
                  MySingleton.Instance.selectedWall.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                MySingleton.Instance.selectedWall.gameObject.transform.position = closest.transform.position - closest_edge; // replace "tester" with the wall object
                if(!MySingleton.Instance.selectedWall.isPlaced)
                {
                    MySingleton.Instance.selectedWall.isPlaced = true;
                    MySingleton.Instance.selectedWall.attachedTile = closest;
                    MySingleton.Instance.selectedWall.edgeIndex = wallIndex;
                }
                else
                {
                    MySingleton.Instance.selectedWall.attachedTile.GetWalled()[MySingleton.Instance.selectedWall.edgeIndex] = false;
                    MySingleton.Instance.selectedWall.attachedTile = closest;
                    MySingleton.Instance.selectedWall.edgeIndex = wallIndex;
                }
                
            }


            //Debug.Log(closest.transform.position);
            //Debug.Log(main_camera.ScreenToWorldPoint(Input.mousePosition));
            if (Input.GetMouseButtonDown(0) && placeMode)
            {
                closest.GetWalled()[wallIndex] = true; // set tile's walled
                //adjacency[closest][wallIndex].GetWalled()[(wallIndex + 3) % 6] = true; // set adjacent tile's walled
                holding_tile = false;
                placeMode = false;
                Press();
                ClearSelection();
                // return both tiles and which index is blocked on each
            }
        }
        if (turns[turnIndex].Execute(this)) //if turn is over
        {
            turnIndex++;
            if (turnIndex > turns.Length - 1) //if the last player has taken their turn
            {
                turnIndex = 0;
                //Debug.Log("Next Player");
                currentPlayer = playerList[++playerIndex % playerList.Length];
            }
        }
    }

    public void RandomizeBoard()
    {
        foreach (Tile t in tiles)
        {
            t.Randomize();
        }
        GameObject.Find("Random Button").SetActive(false);
    }

    public void ClearSelection()
    {
        if (MySingleton.Instance.selectedTile)
        {
            
            MySingleton.Instance.selectedTile.ResetSelection();
        }
        if (MySingleton.Instance.selectedWall)
        {
            MySingleton.Instance.selectedWall.ResetSelection();
        }
    }

    private void make_adjacency()
    {
        foreach (Tile t in tiles)
        {
            Vector3 pos = t.transform.position;
            Tile[] adj = new Tile[6];
            foreach (Tile c in tiles)
            {
                Vector3 cpos = c.transform.position;
                // Debug.Log(pos + " "+ cpos);
                if (Vector3.Distance(pos, cpos + up) < .1)
                {
                    adj[0] = c;
                }
                else if (Vector3.Distance(pos, cpos + up_right) < .1)
                {
                    adj[1] = c;
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

    public void GetUI()
    {
        Canvas[] gameBoard = FindObjectsOfType<Canvas>();
        GameObject test = gameBoard[0].gameObject;
       // Debug.Log(GetCurrentPhaseName());
        if (GetCurrentPhaseName() == "Wall")
        {
            GameObject UI = test.transform.GetChild(0).gameObject;
            UI.SetActive(!UI.activeSelf);
            UI = test.transform.GetChild(2).gameObject;
            if (UI.activeSelf)
            {
                UI.SetActive(!UI.activeSelf);
            }
        }
        else if (GetCurrentPhaseName() == "Rotate")
        {

            GameObject UI = test.transform.GetChild(1).gameObject;
            UI.SetActive(!UI.activeSelf);
            UI = test.transform.GetChild(0).gameObject;
            if (UI.activeSelf)
            {
                UI.SetActive(!UI.activeSelf);
            }
        }
        else
        {
            GameObject UI = test.transform.GetChild(2).gameObject;
            UI.SetActive(!UI.activeSelf);
            UI = test.transform.GetChild(1).gameObject;
            if (UI.activeSelf)
            {
                UI.SetActive(!UI.activeSelf);
            }
        }

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
            rotateTimes--;
        }
        if (rotateTimes == 0)
        {
            Press();
        }

    }

    public void RotateFirstTileRight()
    {
        if (MySingleton.Instance.selectedTile && MySingleton.Instance.selectedTile.IsSelect())
        {
            MySingleton.Instance.selectedTile.RotateRight(1);
            rotateTimes--;
        }
        if (rotateTimes == 0)
        {
            Press();
        }
    }

    public void PlayerMove()
    {
        //Debug.Log(turns[turnIndex].GetCurrentPhase().phaseName);
        if (turns[turnIndex].GetCurrentPhase().phaseName == "Move")
        {
            currentPlayer.Move();
            if(moveTimes == 0)
            {
                Press();
            }
        }
    }

    public string GetCurrentPhaseName()
    {
        return turns[turnIndex].GetCurrentPhase().phaseName;
    }

    public void triggerMode()
    {
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.5f);
        if(currentPlayer.checkWallOwner(MySingleton.Instance.selectedWall))
        {
            placeMode = true;
        }
        removeMode = false;
    }

    public void triggerRemove()
    {
        if(MySingleton.Instance.selectedWall.isPlaced)
        {
            MySingleton.Instance.selectedWall.attachedTile.GetWalled()[MySingleton.Instance.selectedWall.edgeIndex] = false;
            MySingleton.Instance.selectedWall.attachedTile = null;
            removeMode = true;
            placeMode = false;
            MySingleton.Instance.selectedWall.transform.position = MySingleton.Instance.selectedWall.startLocation;
            MySingleton.Instance.selectedWall.isPlaced = false;
            MySingleton.Instance.selectedWall.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            Press();
        }   
    }

    public int GetCurrentPhase()
    {
        if(GetCurrentPhaseName() == "Wall")
        {
            return 0;
        }
        if (GetCurrentPhaseName() == "Rotate")
        {
            return 1;
        }
        if (GetCurrentPhaseName() == "Move")
        {
            return 2;
        }
        return -1;
    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
        //return playerIndex % playerList.Length;
    }

    public void end_game() {
        game_over = true;
        enabled = false;
    }
}
