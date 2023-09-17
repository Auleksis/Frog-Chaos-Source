using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherMode : MonoBehaviour
{
    PlayerController player;

    RoomLogic roomLogic;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        roomLogic = GameObject.Find("Room").GetComponent<RoomLogic>();
    }

    public void SetWalkMode()
    {
        player.SetActionMode(ACTION_MODE.WALK);
        roomLogic.HighlightTilesAroundPlayer();
    }

    public void SetTalkMode()
    {
        player.SetActionMode(ACTION_MODE.TALK);
        roomLogic.DisableHighlighting();
    }

    public void SetFightMode()
    {
        player.SetActionMode(ACTION_MODE.FIGHT);
        roomLogic.DisableHighlighting();
    }
}
