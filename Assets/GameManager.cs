using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  [SerializeField] Tile[] tiles = new Tile[100]; // automatically make and add the tiles with appropriate tags
  [SerializeField] GameObject map;

   // walls_placed[]; // holds how many walls each player has on the board for rotations/movement

    // Start is called before the first frame update
    void Start()
    {
       RandomizeBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void RandomizeBoard() {
    foreach(Tile t in tiles) {
      t.Randomize();
    }
  }

}
