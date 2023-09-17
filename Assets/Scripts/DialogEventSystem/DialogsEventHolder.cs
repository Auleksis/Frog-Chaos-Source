using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogsEventHolder : MonoBehaviour
{
    List<DialogEvent> dialogPoints;
    void Start()
    {
        dialogPoints = new List<DialogEvent>();

        for (int i = 0; i < transform.childCount; i++)
        {
            dialogPoints.Add(transform.GetChild(i).GetComponent<DialogEvent>());
        }
    }

    public DialogEvent GetDialog(int chaosLevel)
    {
        foreach (DialogEvent dialogEvent in dialogPoints)
        {
            dialogEvent.CalculateRealChance(chaosLevel);
            //Debug.Log(dialogEvent.GetRealChance());
        }

        int num = Random.Range(0, 100);

        foreach (DialogEvent dialogEvent in dialogPoints)
        {
            if (!dialogEvent.IsGot() && num <= dialogEvent.GetRealChance())
            {
                return dialogEvent;
            }
        }

        return null;
    }
}
