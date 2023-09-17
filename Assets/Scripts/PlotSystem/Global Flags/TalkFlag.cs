using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkFlag : AbstractFlag
{
    [SerializeField] int talkCountToSetFlag = 1;

    int currentCount = 0;

    public override void ProcessActionAndSetFlag(ACTION_MODE actionMode)
    {
        if(actionMode == ACTION_MODE.TALK)
            currentCount++;

        if(currentCount == talkCountToSetFlag)
            flagValue = true;
    }
}
