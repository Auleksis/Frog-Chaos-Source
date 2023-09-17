using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBadCondition : AbstractCondition
{
    [SerializeField] bool shouldBeGood = true;

    public override bool IsAchieved()
    {
        return roomLogic.IsLastActionGood() && shouldBeGood;
    }
}
