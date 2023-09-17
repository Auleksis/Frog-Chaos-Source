using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPoint : MonoBehaviour
{
    [SerializeField] string dialogText;
    [SerializeField] ConditionalEnding[] endings;
    [SerializeField] bool isAchieved = false;
    [SerializeField] public int requiredChaosLevel = 1;

    [SerializeField] DialogPoint[] mustBeAchievedBefore; 
    
    public string GetDialogText()
    {
        return dialogText;
    }

    public ConditionalEnding Answer()
    {
        foreach(DialogPoint point in mustBeAchievedBefore)
        {
            if(!point.isAchieved)
                return null;
        }

        foreach (ConditionalEnding ending in endings) 
        {
            if (ending.condition.IsAchieved())
            {
                isAchieved = true;
                return ending;
            }
        }

        DialogDenied dialogDenied = GetComponent<DialogDenied>();
        if (!dialogDenied)
            dialogDenied.ShowMessage();

        return null;
    }

    public bool IsAchieved()
    {
        return isAchieved;
    }
}
