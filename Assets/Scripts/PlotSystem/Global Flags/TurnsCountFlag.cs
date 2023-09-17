using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnsCountFlag : AbstractFlag
{
    [SerializeField] int turnsCountToSetFlag = 1;

    int currentTurns = 0;

    public override void ProcessActionAndSetFlag(ACTION_MODE actionMode)
    {
        if (actionMode == ACTION_MODE.WALK)
            currentTurns++;

        if(currentTurns == turnsCountToSetFlag)
            flagValue = true;
    }
}
