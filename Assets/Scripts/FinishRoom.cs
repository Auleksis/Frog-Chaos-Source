using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRoom : MonoBehaviour
{
    RoomLogic roomLogic;

    bool isFinished = false;

    [SerializeField][Multiline] string story;

    [SerializeField] GameObject viewport;

    private void Start()
    {
        roomLogic = GameObject.Find("Room").GetComponent<RoomLogic>();

    }

    private void Update()
    {
        if(!isFinished && roomLogic.IsPlayerPresentHere(transform.position))
        {
            viewport.SetActive(true);
            Debug.Log("You've won!");
            for (int i = 0; i < roomLogic.resultChars.Count; i++)
            {
                story = story.Replace("{" + i +"}", roomLogic.resultChars[i]);
            }
            Debug.Log(story);
            isFinished = true;

            roomLogic.finalStrory = story;
        }
    }
}
