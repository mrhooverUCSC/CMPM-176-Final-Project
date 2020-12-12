using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Sprite[] tileImgs;
    bool[] openings;
    bool[] walled;
    bool[][] tileOpeningList;
    bool isSelected;
    Tile[] AdjcencyTiles;
    // Start is called before the first frame update
    void Start()
    {
        AdjcencyTiles = new Tile[6];
        openings = new bool[6];
        walled = new bool[6] {false, false, false, false, false, false};
        tileOpeningList = new bool[13][];
        //Pre-set opening with differnet tiles
        tileOpeningList[0] = new bool[6] { true, false, false, false, false, false };
        tileOpeningList[1] = new bool[6] { true, false, false, false, false, true };
        tileOpeningList[2] = new bool[6] { true, false, false, false, true, false };
        tileOpeningList[3] = new bool[6] { true, false, false, true, false, false };
        tileOpeningList[4] = new bool[6] { true, false, false, false, true, true };
        tileOpeningList[5] = new bool[6] { true, false, false, true, false, true };
        tileOpeningList[6] = new bool[6] { true, false, true, false, true, false };
        tileOpeningList[7] = new bool[6] { true, true, false, true, false, false };
        tileOpeningList[8] = new bool[6] { true, false, false, true, true, true };
        tileOpeningList[9] = new bool[6] { true, false, true, false, true, true };
        tileOpeningList[10] = new bool[6] { true, false, true, true, false, true };
        tileOpeningList[11] = new bool[6] { true, false, true, true, true, true };
        tileOpeningList[12] = new bool[6] { true, true, true, true, true, true };
    }

    public void Randomize()
    {
        int tileSelection;
        int leftRotate;
        int rightRotate;
        if (this.tag == "region1")
        {
            tileSelection = Random.Range(8, tileImgs.Length);
        }
        else if (this.tag == "region2")
        {
            tileSelection = Random.Range(4, 11);
        }
        else
        {
            tileSelection = Random.Range(0, 6);
        }
        GetComponent<SpriteRenderer>().sprite = tileImgs[tileSelection];
        //openings = tileOpeningList[tileSelection];
        tileOpeningList[tileSelection].CopyTo(openings, 0);
        leftRotate = Random.Range(0, 6);
        rightRotate = Random.Range(0, 6);
        transform.rotation = Quaternion.identity;
        RotateLeft(leftRotate);
        RotateRight(rightRotate);
        //Debug.Log(openings[0].ToString());
        //Debug.Log(openings[1].ToString());
        //Debug.Log(openings[2].ToString());
        //Debug.Log(openings[3].ToString());
        //Debug.Log(openings[4].ToString());
        //Debug.Log(openings[5].ToString());
        //Debug.Log("Done");
    }

    public void RotateLeft(int times)
    {
        while (times > 0)
        {
            transform.Rotate(0, 0, 60);
            //update openings
            bool temp = openings[0];
            for(int index = 0; index < openings.Length; index++)
            {
                if(index + 1 == openings.Length)
                {
                    openings[index] = temp;
                }
                else
                {
                    openings[index] = openings[index + 1];
                }
            }
            times--;
        }
    }

    public void RotateRight(int times)
    {
        while (times > 0)
        {
            transform.Rotate(0, 0, -60);
            //update openings
            bool temp = openings[openings.Length - 1];
            for (int index = openings.Length - 1; index >= 0; index--)
            {
                if (index == 0)
                {
                    openings[index] = temp;
                }
                else
                {
                    openings[index] = openings[index - 1];
                }
            }
            times--;
        }
    }

    public void OnMouseDown()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        if(manager.GetCurrentPhaseName() == "Wall")
        {
            return;
        }
        manager.ClearSelection();
        isSelected = true;
        MySingleton.Instance.selectedTile = this;
        GetComponent<SpriteRenderer>().color = Color.gray;
    }


    public bool IsSelect()
    {
        return isSelected;
    }

    public void ResetSelection()
    {
        isSelected = false;
        if(tag == "Start")
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        else if(tag == "End")
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        } 
    }

    //public void SetAdjcency(Tile[] adj)
    //{
    //    AdjcencyTiles.CopyTo(adj, 0);
    //}

    public bool[] GetOpenings()
    {
        return openings;
    }

    public bool[] GetWalled()
    {
        return walled;
    }
}
