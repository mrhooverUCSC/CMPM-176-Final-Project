using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
   [SerializeField] GameObject[] tiles = new GameObject[14];
   // add a openings array
   //add a walled array


    // Start is called before the first frame update
    void Start()
    {

    }


  // Update is called once per frame
  void Update()
    {
        
    }

  public void Randomize() {
    int tileSelection;
    if(this.tag == "region1") {
      tileSelection = Random.Range(8, 14);
    }
    else if(this.tag == "region2") {
      tileSelection = Random.Range(4, 11);
    }
    else {
      tileSelection = Random.Range(1, 6);
    }
    for(int i = 0; i < 14; i++) {
      tiles[i].SetActive(false);
    }
    tiles[tileSelection].SetActive(true);
    Debug.Log("Changed tiles visibilty");
    // set openings
    // randomly rotate a number of times
  }

  //add a function that rotates openings

  //add a function that places/removes walls

}
