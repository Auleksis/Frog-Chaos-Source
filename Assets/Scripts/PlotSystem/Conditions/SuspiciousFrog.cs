using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspiciousFrog : AbstractCondition
{
    [SerializeField] int suspiciousTurn = 8;
    [SerializeField] FightFlag fightFlag;
    [SerializeField] TalkFlag talkFlag;
    public override bool IsAchieved()
    {
        return roomLogic.GetCurrentTurn() >= suspiciousTurn && !fightFlag.flagValue && !talkFlag.flagValue;
    }
}
