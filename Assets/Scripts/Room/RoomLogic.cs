using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class RoomLogic : MonoBehaviour
{
    Tilemap walls;

    Tilemap highlightLayer;

    Grid grid;

    [SerializeField] public TileBase hightlightTile;

    private PlayerController player;

    [SerializeField] private DialogsEventHolder dialogHolder;

    [SerializeField] private EventHandler eventHandler;

    [SerializeField] private GlobalFlagsHandler globalFlagsHandler;

    [SerializeField] public UIManager uIManager;

    [DllImport("__Internal")]
    private static extern void SaveSession(string data);

    [DllImport("__Internal")]
    private static extern void Log();

    [DllImport("__Internal")]
    private static extern void LoadLastSession();

    [DllImport("__Internal")]
    private static extern void PostHistory(string text);

    [DllImport("__Internal")]
    private static extern void PostOnWall(string text);

    private int good_luck_walk_turn = 50;

    private int good_luck_talk_turn = 60;

    private int good_luck_fight_turn = 30;

    private int good_luck_use_item_turn = 40;

    private int chaosLevel = 1; //Нужно сохранять!

    private int currentTurn = 0;

    public int jabaMood = 1; //От 1 до 4

    public List<string> resultChars;

    public string finalStrory;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        walls = GameObject.Find("Walls").GetComponent<Tilemap>();
        highlightLayer = GameObject.Find("HighlightLayer").GetComponent<Tilemap>();
        grid = GameObject.Find("Grid").GetComponent<Grid>();

        resultChars = new List<string>();

        //При загрузке
        //TODO!!!!
        uIManager.GetDialogPanel().SetAllDialogs(new DialogEvent[1] { dialogHolder.GetDialog(chaosLevel) });

        uIManager.GetChaosDisplayer().UpdateChaosInfo(chaosLevel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SaveSession();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            LoadLastSession();
        }
    }


    public bool IsAllowedToMoveToCell(Vector3Int gridPosition)
    {
        return walls.GetTile(gridPosition) == null;
    }

    public Vector3 TryToMoveToCell(Vector2 click_position)
    {
        Vector3Int gridPos = grid.WorldToCell(click_position);

        Vector3Int playerPos = grid.WorldToCell(player.transform.position);

        float distance = (gridPos - playerPos).sqrMagnitude;

        if (distance <= 1 && IsAllowedToMoveToCell(gridPos))
        {
            Vector3 dMove = new Vector3(grid.cellSize.x * gridPos.x + grid.cellSize.x / 2, grid.cellSize.y * gridPos.y + grid.cellSize.y / 2, 0);

            return dMove;
        }

        return new Vector3(0, 0, 0);
    }

    public void HighlightTile(Vector3 tilePosition)
    {
        Vector3Int pos = grid.WorldToCell(tilePosition);
        highlightLayer.SetTile(pos, hightlightTile);
    }

    public void DehighlightTile(Vector3 tilePosition)
    {
        Vector3Int pos = grid.WorldToCell(tilePosition);
        highlightLayer.SetTile(pos, null);
    }

    public void HighlightTilesAroundPlayer()
    {
        highlightLayer.ClearAllTiles();

        Vector3Int playerPos = grid.WorldToCell(player.transform.position);

        Vector3Int up = playerPos + new Vector3Int(0, 1, 0);
        Vector3Int down = playerPos + new Vector3Int(0, -1, 0);
        Vector3Int right = playerPos + new Vector3Int(1, 0, 0);
        Vector3Int left = playerPos + new Vector3Int(-1, 0, 0);

        Vector3Int[] dirs = { up, down, right, left };
        
        foreach(Vector3Int dir in dirs)
        {
            if (IsAllowedToMoveToCell(dir))
            {
                highlightLayer.SetTile(dir, hightlightTile);
            }
        }
    }

    public void DisableHighlighting()
    {
        highlightLayer.ClearAllTiles();
    }

    public void LoadSession(string json)
    {
        LoadedObject room = JsonUtility.FromJson<LoadedObject>(json);

        SceneManager.LoadScene(room.roomName);
    }

    public void SaveSession()
    {
        LoadedObject loadedObject = new LoadedObject();

        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();


        loadedObject.playerHealth = player.GetHealth();
        loadedObject.playerMoney = player.GetMoney();
        loadedObject.roomName = SceneManager.GetActiveScene().name;

        string result = JsonUtility.ToJson(loadedObject);

        //Debug.Log(result);

        SaveSession(result);
    }

    public bool IsLastActionGood()
    {
        return true;
    }

    public void FinishTurn()
    {

        //оценка хода и генерация события

        ACTION_MODE lastActionMode = player.actionMode;

        bool lastActionWasGood = false;

        switch (lastActionMode)
        {
            case ACTION_MODE.TALK:
                lastActionWasGood = UnityEngine.Random.Range(0, 100) < good_luck_talk_turn;
                break;
            case ACTION_MODE.WALK:
                lastActionWasGood = UnityEngine.Random.Range(0, 100) < good_luck_walk_turn;
                break;
            case ACTION_MODE.FIGHT:
                lastActionWasGood = UnityEngine.Random.Range(0, 100) < good_luck_fight_turn;
                break;
            case ACTION_MODE.USE_ITEM:
                lastActionWasGood = UnityEngine.Random.Range(0, 100) < good_luck_use_item_turn;
                break;
        }


        if (lastActionWasGood && chaosLevel > 1)
            chaosLevel--;
        else if (chaosLevel < 4)
            chaosLevel++;

        jabaMood = UnityEngine.Random.Range(1, 5);

        //Debug.Log("jabaMood = " + jabaMood);

        globalFlagsHandler.ProcessAction(lastActionMode);

        DialogEvent de = dialogHolder.GetDialog(chaosLevel);
        uIManager.GetDialogPanel().SetRandomDialog(de);

        uIManager.GetChaosDisplayer().UpdateChaosInfo(chaosLevel);

        //Debug.Log(chaosLevel);
        EventPoint[] gotEvents = eventHandler.GetRandomEvents(chaosLevel);
        
        foreach(EventPoint p in gotEvents)
        {
            p.Happen();
        }

        uIManager.GetHealthBar().UpdateHealth(player.GetHealth());


        player.actionMode = ACTION_MODE.NONE;

        currentTurn++;
    }

    public int GetChaosLevel()
    {
        return chaosLevel;
    }

    public int GetCurrentTurn()
    {
        return currentTurn;
    }

    public bool IsPlayerPresentHere(Vector3 point)
    {
        Vector3Int pos = grid.WorldToCell(point);

        Vector3Int playerPos = grid.WorldToCell(player.transform.position);

        return pos == playerPos;
    }

    public void PostToWall()
    {
        PostOnWall(finalStrory);
    }

    public void PublishHistory()
    {
        PostHistory(finalStrory);
    }
}
