using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Turn")]
public class Turn : ScriptableObject
{

    public PlayerContainer player;
    int phaseIndex = 0;
    public Phase[] phases;

    private void OnEnable()
    {
        phaseIndex = 0;
    }

    public bool Execute(GameManager gm)
    {
        bool result = false;
        phases[phaseIndex].OnStartPhase(gm);

        if(phases[phaseIndex].IsComplete(gm))
        {
            phases[phaseIndex].OnEndPhase(gm);
            phaseIndex++;
            if (phaseIndex > phases.Length - 1)
            {
                phaseIndex = 0;
                result = true;
            }
        }

        return result;
    }

    public void EndCurrentPhase()
    {
        phases[phaseIndex].forceExit = true;
    }

    public Phase GetCurrentPhase()
    {
        //Debug.Log(phases[phaseIndex].phaseName);
        return phases[phaseIndex];
    }
}


