using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public bool isPlaced;
    bool isSelect;
    // Start is called before the first frame update
    void Start()
    {
        isPlaced = false;
        isSelect = false;
    }

    private void OnMouseDown()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        if(manager.GetCurrentPhaseName() != "Wall")
        {
            return;
        }
        manager.ClearSelection();
        manager.holding_tile = true;
        MySingleton.Instance.selectedWall = this;
        isSelect = true;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public bool IsSelected()
    {
        return isSelect;
    }

    public void ResetSelection()
    {
        isSelect = false;
        GetComponent<SpriteRenderer>().color = Color.black;
    }
}
