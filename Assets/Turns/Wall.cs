﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Phases/Wall")]
public class Wall : Phase
{
    // Start is called before the first frame update
    void Start()
    {
        phaseName = "Wall";
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
    }

    public override void OnEndPhase(GameManager gm)
    {
        isInit = false;
        forceExit = false;
        gm.buttonPressed = false;
    }
}
