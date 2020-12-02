using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Phase : ScriptableObject
{
    public string phaseName;
    public bool forceExit; //exit a phase

    public abstract bool IsComplete(GameManager gm);

    [System.NonSerialized]
    protected bool isInit;

    public abstract void OnStartPhase(GameManager gm);

    public virtual void OnEndPhase(GameManager gm)
    {
        isInit = false;
        forceExit = false;
    }
}
