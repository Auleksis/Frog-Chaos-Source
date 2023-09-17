using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalCondition : AbstractCondition
{
    [SerializeField] FlagInput[] flagsInputs;
    public override bool IsAchieved()
    {
        foreach(FlagInput flagInput in flagsInputs)
        {
            if (!flagInput.flag.flagValue && flagInput.getItsValueAsTrue || !flagInput.flag.flagValue && !flagInput.getItsValueAsTrue)
                return false;
        }
        return true;
    }
}
