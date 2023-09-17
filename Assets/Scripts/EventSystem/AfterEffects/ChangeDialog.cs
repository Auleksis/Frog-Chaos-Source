using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialog : AfterEffect
{
    [SerializeField] DialogHolder holder;
    [SerializeField] RoomLogic roomLogic;
    public override void Apply()
    {
        DialogPoint[] dialogPoints = holder.GetRandomPoints(1, roomLogic.GetChaosLevel());

        if (dialogPoints.Length > 0)
        {
            DialogPoint dialogPoint = holder.GetRandomPoints(1, roomLogic.GetChaosLevel())[0];
            //roomLogic.uIManager.GetDialogPanel().SetRandomDialog(dialogPoint);
        }
        else
        {
            //roomLogic.uIManager.GetDialogPanel().SetAllDialogs(new DialogPoint[0]);
        }
    }
}
