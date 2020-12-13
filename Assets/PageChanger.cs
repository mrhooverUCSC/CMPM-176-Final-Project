using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageChanger : MonoBehaviour
{
    string[] rulePages;
    int index = 0;
    public Text TextArea;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
    public Image image6;
    public Image image7;

    // Start is called before the first frame update
    void Start()
    {
        string Page1 = "Objective\nIn Hex Maze, your goal is to move your character piece from the start of the maze to the exit tile by rotating the hexes and making paths so you can escape.\n";
        string Page2 = "Setup\nTo start the game, click";
        string Page3 = "Taking a Turn\nA turn is split into three different parts: Wall, Rotate and Move.  The banner at the top of the screen will indicate who’s turn it is and what phase you are currently on.";
        string Page4 = "Wall Phase\nWalls can be placed on the edges between tiles to block off the path of other players.  However, walls may not be played on the edge of a starting tile.  During the wall phase, you may choose to perform one of three options: \nPlace one of your walls - To place a wall, click one of your unplaced walls.  Then, click on the “                ” button on the bottom right corner of the screen.  Finally, click where you would like to place the wall.\n" +
            "Move one of your walls - To move a wall, click one of your placed walls. Then, click on the\n “                ” button on the bottom right corner of the screen. Finally, click where you would like to move the wall.\n" +
            "Remove an opponent’s wall - To remove a wall, select a wall by clicking on it, and then click on the “                ” button at the bottom right corner of the screen.\n";
        string Page5 = "Rotate Phase\nThe second part of your turn allows you to rotate a number of hex tiles.  To rotate a tile, click on the tile you wish to rotate, and then click on the “                ” button to rotate counter-clockwise or the “                ” button to rotate clockwise.  A single rotation turns a tile 60°, but a tile can be rotated more than once per turn.  The number of tiles you can rotate is up to the current number of walls your opponents have in total / 2 rounded up.  Your remaining rotations are indicated by a counter at the top left of the screen.  Once you are done rotating or your amount of rotations reaches 0, you can proceed to the next phase by clicking the Next Phase button.";
        string Page6 = "Move Phase\nThe move phase is when you get to move your player pawn.  Tiles are considered Valid Tiles if they have connected paths and are not separated by a wall.  To move, click on a Valid Tile that is adjacent to your pawn, then click the “                        ” button.  Players cannot move onto the tile that another player is on. You can move a number of hexes up to the number of walls that you currently have on the board.  Your remaining movement is indicated at the top left corner of the screen.  You may end the move phase before you use up all your movement by clicking the Next Phase Button.";
        string Page7 = "Ending the Game\nThe game ends immediately when a character moves onto the exit.  The player that reached the exit wins.";

        rulePages = new string[7]{Page1, Page2, Page3, Page4, Page5, Page6, Page7};
        TextArea.text = rulePages[index];

        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
        image5.gameObject.SetActive(false);
        image6.gameObject.SetActive(false);
        image7.gameObject.SetActive(false);
    }

    public void NextPage()
    {
        index++;
        if (index > 6)
        {
            index = 6;
            return;
        }
        TextArea.text = rulePages[index];
    }

    public void LastPage()
    {
        index--;
        if (index < 0)
        {
            index = 0;
            return;
        }
        TextArea.text = rulePages[index];
    }
    // Update is called once per frame
    void Update()
    {
        if(index == 1)
        {
            image1.gameObject.SetActive(true);
        }
        else
        {
            image1.gameObject.SetActive(false);
        }

        if(index == 3)
        {
            image2.gameObject.SetActive(true);
            image3.gameObject.SetActive(true);
            image4.gameObject.SetActive(true);
        }
        else
        {
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(false);
            image4.gameObject.SetActive(false);
        }

        if(index == 4)
        {
            image5.gameObject.SetActive(true);
            image6.gameObject.SetActive(true);
        }
        else
        {
            image5.gameObject.SetActive(false);
            image6.gameObject.SetActive(false);
        }

        if(index == 5)
        {
            image7.gameObject.SetActive(true);
        }
        else
        {
            image7.gameObject.SetActive(false);
        }
    }
}

