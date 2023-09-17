using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageBox : MonoBehaviour
{
    [SerializeField] GameObject viewport;
    [SerializeField] TMP_Text content;

    Queue<string> messages;

    private void Awake()
    {
        messages = new Queue<string>();
    }

    public void Show()
    {
        viewport.SetActive(true);
        if(messages.Count > 0)
        {
            string text = messages.Dequeue();
            content.text = text;
        }
    }

    public void Hide()
    {
        viewport.SetActive(false);
    }
    
    public void AddToQueue(string message)
    {
        messages.Enqueue(message);
    }

    public void ClickOK()
    {
        if (messages.Count > 0)
        {
            string text = messages.Dequeue();
            content.text = text;
        }
        else
        {
            Hide();
        }
    }

    public bool IsOkPressed()
    {
        return !viewport.activeSelf;
    }
}
