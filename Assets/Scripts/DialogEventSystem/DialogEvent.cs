using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CALCMODE { LINERAL, INVERSE}
public class DialogEvent : MonoBehaviour
{
    [SerializeField] bool isGot;

    [SerializeField][Multiline] string text;

    [SerializeField] int defaultChance = 50;

    int realChance = 50;

    [SerializeField] float coef = 1;

    List<Answer> answers;

    [SerializeField] CALCMODE mode;

    string player_bio;

    RoomLogic roomLogic;

    void Start()
    {
        roomLogic = GameObject.Find("Room").GetComponent<RoomLogic>();  

        answers = new List<Answer>();

        for (int i = 0; i < transform.childCount; i++)
        {
            answers.Add(transform.GetChild(i).GetComponent<Answer>());
        }
    }

    public void CalculateRealChance(int chaosLevel)
    {
        switch (mode)
        {
            case CALCMODE.LINERAL:
                realChance = (int)((chaosLevel - 1) / 4.0f * coef * defaultChance) + Random.Range(1, 10);
                break;

            case CALCMODE.INVERSE:
                realChance = (int)((float)defaultChance / (coef * (float)chaosLevel)) + Random.Range(1, 10);
                break;
        }
    }


    public bool IsGot()
    {
        return isGot;
    }

    public int GetRealChance()
    {
        return realChance;
    }

    public string GetDialogText()
    {
        return text;
    }

    public string GetAnswer()
    {
        foreach(Answer answer in answers)
        {
            if (answer.condition.IsAchieved())
            {
                roomLogic.resultChars.Add(answer.biography);
                isGot = true;
                return answer.answer_text;
            }
        }
        return "Походите ещё. Вы не создали нужных условий для получения ответа";
    }
}
