using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightFrog : AbstractCondition
{
    [SerializeField] FightFlag fightFlag;
    public override bool IsAchieved()
    {
        return fightFlag.flagValue;
    }
}
