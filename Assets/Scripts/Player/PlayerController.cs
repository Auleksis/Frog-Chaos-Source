using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ACTION_MODE { NONE, TALK, WALK, FIGHT, USE_ITEM}
public class PlayerController : MonoBehaviour
{
    [SerializeField] RoomLogic room;

    public ACTION_MODE actionMode;

    private int health = 3;

    private int money = 0;


    void Start()
    {
        
    }

    void Update()
    {
        if (actionMode == ACTION_MODE.WALK && Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dMove = room.TryToMoveToCell(clickPosition);


            if (dMove.sqrMagnitude != 0)
            {
                transform.position = dMove;
                room.DisableHighlighting();
                room.FinishTurn();
            }
        }
    }

    public void SetActionMode(ACTION_MODE actionMode)
    {
        this.actionMode = actionMode;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMoney()
    {
        return money;
    }
}
