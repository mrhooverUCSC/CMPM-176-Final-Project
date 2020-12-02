using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Phases/Move")]
public class Move : Phase
{

    public override bool IsComplete(GameManager gm)
    {
        //if next phase button is pressed return true
        return gm.buttonPressed;
    }

    public override void OnStartPhase(GameManager gm)
    {
        if (isInit)
            return;
        isInit = true;
        Debug.Log("Should print");
        MakeMove(gm);
    }

    public override void OnEndPhase(GameManager gm)
    {
        gm.buttonPressed = false;
    }

    void MakeMove(GameManager gm)
    {
        gm.ToggleVisibility();
        //show move UI
        //hide non move UI
    }
}