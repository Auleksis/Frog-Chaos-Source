using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] DialogButton[] dialogButtons;

    public void Show()
    {
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }

    public void SetRandomDialog(DialogEvent dialogPoint)
    {
        int index = Random.Range(0, 1);
        dialogButtons[index].gameObject.SetActive(true);
        dialogButtons[index].SetDialog(dialogPoint);
    }

    public void SetAllDialogs(DialogEvent[] dialogPoints)
    {
        int last = 0;
        for(int i = 0; i < dialogPoints.Length; i++)
        {
            dialogButtons[i].gameObject.SetActive(true);
            dialogButtons[i].SetDialog(dialogPoints[i]);
            Debug.Log(i);
            last = i;
        }

        for(int i = last + 1; i < dialogButtons.Length; i++)
        {
            dialogButtons[i].gameObject.SetActive(false);
        }
    }
}
