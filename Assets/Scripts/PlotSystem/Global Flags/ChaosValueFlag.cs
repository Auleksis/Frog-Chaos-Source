using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosValueFlag : AbstractFlag
{
    [SerializeField] int neccessaryValue = 1;

    public override void ProcessActionAndSetFlag(ACTION_MODE actionMode)
    {
        if (roomLogic.GetChaosLevel() == neccessaryValue)
            flagValue = true;
        else
            flagValue = false;
    }
}
