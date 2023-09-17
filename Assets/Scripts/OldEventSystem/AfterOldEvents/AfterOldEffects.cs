using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AfterOldEffects : MonoBehaviour
{
    protected RoomLogic roomLogic;

    private void Awake()
    {
        roomLogic = GameObject.Find("Room").GetComponent<RoomLogic>();
    }

    public abstract void Apply();
}
