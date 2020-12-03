using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

[CreateAssetMenu(menuName = "Phases/Rotate")]
public class Rotate : Phase
{
    void Awake()
    {
        phaseName = "Rotate";
    }
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
        RotatePawn(gm);
    }

    public override void OnEndPhase(GameManager gm)
    {
        isInit = false;
        forceExit = false;
        gm.buttonPressed = false;
    }

    void RotatePawn(GameManager gm)
    {
        gm.ToggleVisibility();
        //show rotate UI
        //hide non rotate UI
    }
}
