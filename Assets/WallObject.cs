using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObject : MonoBehaviour
{
    [SerializeField] Sprite[] tileImgs;
    int owner;
  GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

  public void OnMouseDown() {
    // gm.function();
  }

  void set_owner(int o) {
    owner = o;
    GetComponent<SpriteRenderer>().sprite = tileImgs[o];
  }

  void game_manager(GameManager g) {
    gm = g;
  }
}
