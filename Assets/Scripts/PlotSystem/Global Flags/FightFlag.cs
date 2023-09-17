using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightFlag : AbstractFlag
{
    [SerializeField] int hitCountToSetFlag = 1;

    int currentCount = 0;

    public override void ProcessActionAndSetFlag(ACTION_MODE actionMode)
    {
        if (actionMode == ACTION_MODE.FIGHT)
            currentCount++;

        if (currentCount == hitCountToSetFlag)
            flagValue = true;
    }
}
