using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCondition : MonoBehaviour
{
    protected RoomLogic roomLogic;

    protected virtual void Awake()
    {
        roomLogic = GameObject.Find("Room").GetComponent<RoomLogic>();
    }

    public abstract bool IsAchieved();
}
