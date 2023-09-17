using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFlag : MonoBehaviour
{
    protected RoomLogic roomLogic;

    protected virtual void Awake()
    {
        roomLogic = GameObject.Find("Room").GetComponent<RoomLogic>();
    }

    public bool flagValue = false;
    public abstract void ProcessActionAndSetFlag(ACTION_MODE actionMode);
}
