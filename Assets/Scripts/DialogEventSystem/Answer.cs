using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Answer : MonoBehaviour
{
    [SerializeField][Multiline] public string answer_text;

    [SerializeField] public UniversalCondition condition;

    [SerializeField][Multiline] public string biography;
}
